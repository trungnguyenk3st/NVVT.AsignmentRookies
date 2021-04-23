import React from "react";
import { Card, CardBody } from "reactstrap";

export default function SplitLayout({ title, actions, content }) {
  return (
    <div>
      <Card className="border-0">
        <CardBody>
          <div className="clearfix">
            <h4 className="float-left">{title}</h4>
            <div className="float-right">{actions}</div>
          </div>
        </CardBody>
        <CardBody>{content}</CardBody>
      </Card>
    </div>
  );
}