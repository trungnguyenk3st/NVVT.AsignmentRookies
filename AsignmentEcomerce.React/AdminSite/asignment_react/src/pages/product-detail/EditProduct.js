import React from "react";
import { Button, Form, FormGroup, Label, Input } from "reactstrap";
import SelectCategory from "../../components/SelectCategory";

export default function EditProduct({ itemEdit, onSave, onCancel }) {
  console.log(itemEdit);
  const itemId = itemEdit?.idProduct ?? 0;
  const [inputName, setInputName] = React.useState("");
  const [inputPrice, setInputPrice] = React.useState("");
  const [inputDescription, setInputDescription] = React.useState("");
  const [inputCate, setInputCate] = React.useState(0);

  
  React.useEffect(() => {
    console.log(itemId);
    setInputName(itemEdit?.nameProduct);
    setInputCate(itemEdit?.idCategory);
    setInputPrice(itemEdit?.unitPrice);
    setInputDescription(itemEdit?.description);
    console.log("Set initial value");
  }, [itemEdit]);

  const imageRef = React.useRef(null);
  const [preview,setPreview] = React.useState(null);
  //handle form
  const handleChangeName = (e) => setInputName(e.target.value);
  const handleChangePrice = (e) => setInputPrice(e.target.value);
  const handleChangeDescription = (e) => setInputDescription(e.target.value);
  const handleChangeCate = (val) => setInputCate(val);
  const handleImages = (e)=>setPreview(URL.createObjectURL(e.target.files[0]));

  //handle
  const handleSubmit = () => {
    if (inputName && inputPrice && inputCate)
        onSave({
          IDProduct: itemId,
          NameProduct: inputName,
          UnitPrice: inputPrice,
          Description: inputDescription,
          IDCategory: inputCate,
          ImageUrl: imageRef.current.files[0],
        });
    else window.alert("Please fill the form below");
  };
  //
  return (
    <Form>
      <FormGroup>
        <Label for="Name">Product Name</Label>
        <Input
          invalid={!inputName}
          type="text"
          name="Name"
          onChange={handleChangeName}
          value={inputName}
        />
      </FormGroup>

      <FormGroup>
        <Label for="Price">Product Price</Label>
        <Input
          invalid={!inputPrice}
          type="text"
          name="Price"
          onChange={handleChangePrice}
          value={inputPrice}
        />
      </FormGroup>

      <FormGroup>
        <Label for="Type">Select Category</Label>
        <SelectCategory
          placeholder="Choose category"
          initalValue={inputCate}
          onChange={handleChangeCate}
        />
      </FormGroup>

      <FormGroup>
        <Label for="ProductDescription">Product Description</Label>
        <Input
          type="textarea"
          name="ProductDescription"
          onChange={handleChangeDescription}
          value={inputDescription}
        />
      </FormGroup>

      <FormGroup>
        <Label for="Image">Product Image</Label>
        <Input
          type="file"
          innerRef={imageRef}
          name="Image"
          onChange={handleImages}
        />
          <img key={1} src={preview} alt="Choose Image" className="img-fluid" style={{width:"250px"}}/>
      </FormGroup>

      <div className="pt-3">
        <Button color="primary" className="mr-3" onClick={handleSubmit}>
          Save
        </Button>
        <Button color="danger" onClick={() => onCancel && onCancel()}>
          Cancel
        </Button>
      </div>
    
    </Form>
  );
}