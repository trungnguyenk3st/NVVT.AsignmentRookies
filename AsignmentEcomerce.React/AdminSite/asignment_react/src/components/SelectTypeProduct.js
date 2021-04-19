import React from "react";
import { Input } from "reactstrap";
import _typeSer from "../services/typeService";

export default function SelectTypeProduct({
  initalValue,
  onChange,
  placeholder = false,
}) {
  const [inputType, setInputType] = React.useState(0);
  const [listTypes, setTypes] = React.useState([]);

  React.useEffect(() => {
    _typeSer.getList().then((resp) => setTypes(resp.data));
  }, []);

  React.useEffect(() => {
    setInputType(initalValue);
  }, [initalValue]);

  //handle
  const handleChangeType = (e) => {
    let val = e.target.value;
    setInputType(val);
    onChange && onChange(val);
  };

  return (
    <Input
      type="select"
      name="Type"
      id="Type"
      placeholder="Select type product"
      invalid={!inputType}
      onChange={handleChangeType}
      value={inputType}
    >
      {placeholder && (
        <option className="text-secondary" value={0}>
          Choose Type
        </option>
      )}
      {listTypes.map((item) => (
        <option key={+item.Id} value={item.Id}>
          {item.Name}
        </option>
      ))}
    </Input>
  );
}