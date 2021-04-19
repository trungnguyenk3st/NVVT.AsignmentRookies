import React from "react";
import { Button } from "reactstrap";

export default function Header(props) {
  return (
    <div className="clearfix">
      <div className="float-left">
        <img width="40" src="./logo192.png" alt="" />
      </div>
      <Button color="link" className="float-right text-danger" size="sm">
        Sign Out
      </Button>
    </div>
  );
}