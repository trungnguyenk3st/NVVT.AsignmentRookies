import axios from "axios";
import { host } from "../config";

class typeService {
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

export default new typeService("typeproduct", "Type Product");