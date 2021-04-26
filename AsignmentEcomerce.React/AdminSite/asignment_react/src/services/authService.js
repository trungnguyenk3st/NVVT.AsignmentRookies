import { UserManager } from "oidc-client";
import { storeUserError, storeUser } from "../actions/authAction";

const config = {
  authority: "https://localhost:44342",
  client_id: "react_app",
  redirect_uri: "http://localhost:3000/signin-oidc",
  response_type: "id_token token",
  scope: "openid profile rookieshop.api",
  post_logout_redirect_uri: "http://localhost:3000/signout-callback-oidc",
  front_channel_logout_uri: "http://localhost:3000/signout-oidc",
};

const userManager = new UserManager(config);

export async function loadUserFromStorage(store) {
  try {
    let user = await userManager.getUser();
    if (!user) {
      return store.dispatch(storeUserError());
    }
    store.dispatch(storeUser(user));
  } catch (e) {
    console.error(`User not found: ${e}`);
    store.dispatch(storeUserError());
  }
}

export function signinRedirect() {
  return userManager.signinRedirect();
}

export function signinRedirectCallback() {
  return userManager.signinRedirectCallback();
}

export function signoutRedirect() {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirect();
}

export function signoutRedirectCallback() {
  userManager.clearStaleState();
  userManager.removeUser();
  return userManager.signoutRedirectCallback();
}

export default userManager;