import React, { useEffect } from "react";
import { signoutRedirectCallback } from "../../services/authService";
import { useHistory } from "react-router-dom";

function SignoutOidc() {
  const history = useHistory();
  useEffect(() => {
    async function signoutAsync() {
      await signoutRedirectCallback();
      history.push("/");
    }
    signoutAsync();
  }, [history]);

  return <div>Sign Out Redirecting...</div>;
}

export default SignoutOidc;