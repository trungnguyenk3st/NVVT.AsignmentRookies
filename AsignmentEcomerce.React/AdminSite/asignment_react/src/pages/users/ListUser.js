import React from "react";
import { Table } from "reactstrap";

export default function ListUser({ datas }) {
  return (
    <>
      {(!datas || datas.length < 1) && (
        <p className="py-5 text-center text-uppercase text-secondary">
          No data
        </p>
      )}
      {datas.length > 0 && (
        <Table>
          <thead>
            <tr>
              <th>Id</th>            
              <th>Email</th>
              {/* <th>Phone</th> */}
            </tr>
          </thead>
          <tbody>
            {datas.map((item, index) => (
              <tr key={+index}>
                <th>{item.id_user}</th>
                <td>{item.mail_user}</td>
                {/* <td>{item.phone}</td> */}
              </tr>
            ))}
          </tbody>
        </Table>
      )}
    </>
  );
}