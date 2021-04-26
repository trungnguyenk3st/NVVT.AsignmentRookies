import React, { useEffect } from "react";
import { signinRedirectCallback } from "../../services/authService";
import { useHistory } from "react-router-dom";

function SigninOidc() {
  const history = useHistory();
  useEffect(() => {
    async function signinAsync() {
      await signinRedirectCallback();
      history.push("/");
    }
    signinAsync();
  }, [history]);

  return <div>Sign In Redirecting...</div>;
}

export default SigninOidc;