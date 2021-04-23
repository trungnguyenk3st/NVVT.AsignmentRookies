import React from "react";
import { Button } from "reactstrap";
import SingleLayout from "../../containers/SingleLayout";
import SearchBar from "../../components/SearchBar";
import ListProduct from "./ListProduct";
import { useHistory } from "react-router";

import _prodSer from "../../services/productService";

const _parmas = {
  query: "",
  cateId: 0,
  sort: null,
};

export default function Product(props) {
  const [listProducts, setProducts] = React.useState([]);
  const history = useHistory();
  React.useEffect(() => {
    _fetchProducts();
  }, []);

  //handle
  const _fetchProducts = () => {
    _prodSer.getList(_parmas).then((resp) => {
      setProducts(resp.data);
    });
  };

  const handleChangeCate = (val) => {
    _parmas.idCategory = val;
    _fetchProducts();
  };

  const handleChangeSort = (val) => {
    if (val < 0) _parmas.sort = null;
    else _parmas.sort = val;
    _fetchProducts();
  };

  const handleSearch = (query) => {
    _parmas.query = query;
    _fetchProducts();
  };

  const handleCreate = () => {
    history.push("/products/0");
  };

  const handleRefressh = () => {
    _parmas.typeId = 0;
    _parmas.sort = null;
    _parmas.query = "";
    _fetchProducts(1);
  };

  return (
    <SingleLayout
      title="List Product"
      actions={
        <div className="d-flex">
          <Button onClick={handleRefressh} color="link">
            Refresh
          </Button>
          <SearchBar
            placeholder="Product name ..."
            onSearchSubmit={handleSearch}
          />
          <Button
            className="ml-3"
            color="primary"
            children="New"
            onClick={() => handleCreate()}
          />
        </div>
      }
      content={
        <>
          <ListProduct
            datas={listProducts}
            onChangeCate={handleChangeCate}
            onChangeSort={handleChangeSort}
          />
        </>
      }
    />
  );
}