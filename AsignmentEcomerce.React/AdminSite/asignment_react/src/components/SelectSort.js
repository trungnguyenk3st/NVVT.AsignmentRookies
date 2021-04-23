import React from "react";
import { Input } from "reactstrap";

const listItems = ["Low", "High", "Popular"];

export default function SelectSort({
  initalValue,
  onChange,
  placeholder = null,
  ...other
}) {
  const [inputItem, setInputItem] = React.useState(0);

  React.useEffect(() => {
    setInputItem(initalValue);
  }, [initalValue]);

  //handle
  const handleChange = (e) => {
    let val = e.target.value;
    setInputItem(val);
    onChange && onChange(val);
  };

  return (
    <Input {...other} type="select" onChange={handleChange} value={inputItem}>
      {placeholder && (
        <option className="text-secondary" value={-1}>
          {placeholder}
        </option>
      )}
      {listItems.map((item, index) => (
        <option key={+index} value={index}>
          {item}
        </option>
      ))}
    </Input>
  );
}