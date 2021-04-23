import React from "react";
import { Pagination, PaginationItem, PaginationLink } from "reactstrap";

export default function Paging({ totalPage, initalPage = 1, onChangePage }) {
  const [pageSelected, setPage] = React.useState(initalPage);
  let arrayUris = [];

  //handle
  const handleClickPage = (page) => {
    setPage(page);
    onChangePage && onChangePage(page);
  };

  for (let page = 1; page <= totalPage; page++) {
    arrayUris.push(
      <PaginationItem active={page === pageSelected}>
        <PaginationLink onClick={() => handleClickPage(page)}>
          {page}
        </PaginationLink>
      </PaginationItem>
    );
  }

  return <>{totalPage > 0 && <Pagination>{arrayUris}</Pagination>}</>;
}