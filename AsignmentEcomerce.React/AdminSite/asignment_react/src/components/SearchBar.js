import React from "react";
import { InputGroup, InputGroupAddon, Button, Input } from "reactstrap";

export default function SearchBar({
  placeholder = "Search something ...",
  onSearchSubmit,
}) {
  const inputRef = React.useRef(null);
  const handleSubmit = () => {
    let val = inputRef.current.value;
    onSearchSubmit && onSearchSubmit(val);
  };

  return (
    <InputGroup>
      <Input innerRef={inputRef} placeholder={placeholder} />
      <InputGroupAddon addonType="append" onClick={handleSubmit}>
        <Button color="success">Search</Button>
      </InputGroupAddon>
    </InputGroup>
  );
}
