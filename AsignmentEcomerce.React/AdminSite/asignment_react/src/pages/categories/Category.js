import React from "react";
import { Button } from "reactstrap";
import SplitLayout from "../../containers/SplitLayout";
import EditCategory from "./EditCategory";
import ListCategory from "./ListCategory";
import _cateSer from "../../services/cateService";

//comp
export default function Product() {
  const [listCategory, setCategory] = React.useState([]);
  const [itemSelected, setSelected] = React.useState(null);

  React.useEffect(() => {
   handleChangeCate();
  }, []);

  //handle
  const handleChangeCate = () => {
    _cateSer.getList().then((resp) => {
      setCategory(resp.data);
      // console.log(resp.data);
    });
  };

  const handleCreate = () => setSelected({ Name: ""});
  const handleEdit = (item) => setSelected(item);
  const handleCancel = () => setSelected(null);
  const handleDelete = (itemId) => {
    let result = window.confirm("Delete this item?");
    if (result) {
      _cateSer.delete(itemId).then((resp) => {
        setCategory(_removeViewItem(listCategory, itemId));
      });
    }
  };

  const handleSave = (data) => {
    let result = window.confirm("Save the changed items?");
    if (result) {
      if (!data.idCategory) {
        _cateSer.create(data).then((resp) => {
          handleChangeCate(data);
        });
      } else {
        _cateSer.edit(data.idCategory, data).then((resp) => {
          setCategory(_updateViewItem(listCategory, data));
        });
      }
      setSelected(null);
    }
  };

  //update view
  const _removeViewItem = (lists, itemDel) =>
    lists.filter((item) => item.idCategory !== itemDel);

  const _updateViewItem = (lists, itemEdit) =>
    lists.map((item) => (item.idCategory === itemEdit.idCategory ? itemEdit : item));
  //
  return (
    <SplitLayout
      title="Category"
      actions={
        <Button
          color="primary"
          className="float-right"
          children="New Category"
          onClick={() => handleCreate()}
        />
      }
      right={
        <ListCategory
          datas={listCategory}
          onEdit={handleEdit}
          onDelete={handleDelete}
          // onChangeType={handleChangeType}
        />
      }
      left={
        <EditCategory
          itemEdit={itemSelected}
          onCancel={handleCancel}
          onSave={handleSave}
        />
      }
    ></SplitLayout>
  );
}