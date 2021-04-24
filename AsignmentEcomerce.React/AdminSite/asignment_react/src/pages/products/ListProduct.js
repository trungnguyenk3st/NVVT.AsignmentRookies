import React from "react";
import { Button, Table } from "reactstrap";
import SelectSort from "../../components/SelectSort";
import ProductImage from "../../components/ProductImage";
import SelectCategory from "../../components/SelectCategory";
import { Link } from "react-router-dom";

export default function ListProduct({ datas, onChangeCate, onChangeSort }) {
  return (
    <Table className="my-table">
      <thead>
        <tr>
          <th>#</th>
          <th>Image</th>
          <th>Name</th>
          <th>
            <div className="d-flex align-items-center">
              <span className="pr-2">Category</span>
              <SelectCategory
                initalValue={0}
                novalid
                placeholder="All"
                className="border-0"
                onChange={onChangeCate}
              />
            </div>
          </th>
          <th>
            <div className="d-flex align-items-center">
              <span className="pr-2">Price</span>
              <SelectSort
                placeholder="All"
                className="border-0"
                onChange={onChangeSort}
              />
            </div>
          </th>
          <th></th>
        </tr>
      </thead>
      <tbody>
        {(!datas || datas.length < 1) && (
          <tr>
            <td colSpan={7}>
              <p className="py-5 text-center text-uppercase text-secondary">
                No data
              </p>
            </td>
          </tr>
        )}
        {datas.length > 0 &&
          datas.map((item, index) => (
            <tr key={+index}>
              <th scope="row">{item.idProduct}</th>
              <td>
                <ProductImage src={item.imageUrl} />
              </td>
              <td>{item.nameProduct}</td>
              <td>{item.nameCategory}</td>
              <td>{item.unitPrice}</td>
              <td>{item.description}</td>
            
              <td className="text-right">
                <Button color="link">
                  <Link to={"/product/" + item.idProduct}>Edit</Link>
                </Button>
              </td>
            </tr>
          ))}
      </tbody>
    </Table>
  );
  
}