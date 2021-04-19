import React from "react";
import { Card, CardBody, Col, Row } from "reactstrap";

export default function SplitLayout({ title, actions, right, left }) {
  return (
    <div>
      <Card className="border-0">
        <CardBody>
          <div className="clearfix">
            <h4 className="float-left">{title}</h4>
            <div className="float-right">{actions}</div>
          </div>
        </CardBody>
        <CardBody>
          <Row>
            <Col xs="6">{right}</Col>
            <Col xs={{ size: 5, offset: 1 }}>{left}</Col>
          </Row>
        </CardBody>
      </Card>
    </div>
  );
}