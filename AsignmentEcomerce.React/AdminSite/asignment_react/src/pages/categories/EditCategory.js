import React from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";


export default function EditCategory({ itemEdit, onSave, onCancel }) {
  const itemId = itemEdit?.idCategory ?? 0;
  const [inputName, setInputName] = React.useState("");

  React.useEffect(() => {
    setInputName(itemEdit?.nameCategory);
  }, [itemEdit]);

  const handleChangeName = (e) => setInputName(e.target.value);
  //
  const handleSubmit = () => {
    if (inputName )
      onSave({ idCategory: itemId, nameCategory: inputName});
    else window.alert("Please fill the form below");
  };
  //
  return (
    <>
      {!itemEdit && (
        <p className="pt-5 text-center text-uppercase text-secondary">
          Select item
        </p>
      )}
      {itemEdit && (
        <Form>
          <FormGroup>
            <Label for="Name">Category Name</Label>
            <Input
              invalid={!inputName}
              type="text"
              name="Name"
              id="Name"
              onChange={handleChangeName}
              value={inputName}
            />
          </FormGroup>
         
          <div className="pt-3">
            <Button color="primary" className="mr-3" onClick={handleSubmit}>
              Save
            </Button>
            <Button color="danger" onClick={() => onCancel()}>
              Cancel
            </Button>
          </div>
        </Form>
      )}{" "}
    </>
  );
}