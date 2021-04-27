import React from "react";
import { Button } from "reactstrap";
import { useSelector } from "react-redux";
import { signoutRedirect } from "../services/authService";

export default function Header(props) {
  const user = useSelector((state) => state.auth.user);

  const signOut = () => signoutRedirect();
  return (
    <div className="clearfix">
      <div className="float-left">
        <img width="180" src="./logo.png" alt="" />
      </div>
      <div className="float-right ">
        <span>Hello,{user?.profile.name}</span>
        <Button
          color="link"
          onClick={signOut}
          className="pl-3 text-danger"
          size="sm"
        >
          Sign Out
        </Button>
      </div>
    </div>
  );
}