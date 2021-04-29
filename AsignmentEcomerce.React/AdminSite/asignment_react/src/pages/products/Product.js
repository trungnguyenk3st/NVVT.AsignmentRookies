import React from "react";
import { Button } from "reactstrap";
import SingleLayout from "../../containers/SingleLayout";
import SearchBar from "../../components/SearchBar";
import ListProduct from "./ListProduct";
import { useHistory } from "react-router";

import _prodSer from "../../services/productService";


export default function Product(props) {
  const [listProducts, setProducts] = React.useState([]);
  const history = useHistory();
  React.useEffect(() => {
    _fetchProducts();
  }, []);

  //handle
  const _fetchProducts = () => {
    _prodSer.getList().then((resp) => {
      setProducts(resp.data);
    });
  };

  const handleChangeCate = (val) => {
    _prodSer.getByCategory(val).then()
  };

  const handleCreate = () => {
    history.push("/product/0");
  };

  const handleRefressh = () => {
    _fetchProducts();
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
          />
        </>
      }
    />
  );
}