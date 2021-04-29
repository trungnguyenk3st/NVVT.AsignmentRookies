import axios from "axios";
import { host } from "../config";

class userService {
  constructor(pathSer, aliasName) {
    this.pathSer = pathSer;
    this.aliasName = aliasName;
  }

  getList() {
    return axios({
      url: host + "/" + this.pathSer,
      method: "get",
      actionName: `Get list ${this.aliasName}`,
    });
  }
}

export default new  userService("user", "Name User");