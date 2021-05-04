import { UserManager } from "oidc-client";
import { storeUserError, storeUser } from "../actions/authAction";

const config = {
  authority: "https://backende069e98663574dd58d6fe43c48b63058.azurewebsites.net",
  client_id: "react_app",
  redirect_uri: "https://sad52fe2d276454672b1548a.z23.web.core.windows.net/signin-oidc",
  response_type: "id_token token",
  scope: "openid profile rookieshop.api",
  post_logout_redirect_uri: "https://sad52fe2d276454672b1548a.z23.web.core.windows.net/signout-callback-oidc",
  front_channel_logout_uri: "https://sad52fe2d276454672b1548a.z23.web.core.windows.net/signout-oidc",
};

const userManager = new UserManager(config);

export async function loadUserFromStorage(store) {
  try {
    let user = await userManager.getUser();
    console.log(user);
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