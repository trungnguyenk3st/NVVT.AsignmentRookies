import axios from "axios";
import { host } from "../config";

export default class commonService {
  constructor(pathSer, aliasName) {
    this.pathSer = pathSer;
    this.aliasName = aliasName;
  }

  getList(queryString = "") {
    return axios({
      url: host + "/" + this.pathSer + queryString,
      method: "get",
      actionName: `Get list ${this.aliasName}`,
    });
  }

  get(id) {
    return axios({
      url: host + "/" + this.pathSer + "/" + id,
      method: "get",
      actionName: `Get ${this.aliasName} with ID: ${id}`,
    });
  }

  edit(id, object) {
    return axios({
      url: host + "/" + this.pathSer + "/" + id,
      method: "put",
      data: object,
      actionName: `Edit ${this.aliasName} with ID: ${id}`,
    });
  }

  delete(id) {
    return axios({
      url: host + "/" + this.pathSer + "/" + id,
      method: "delete",
      actionName: `Delete ${this.aliasName} with ID: ${id}`,
    });
  }

  create(object, queryString = "") {
    return axios({
      url: host + "/" + this.pathSer + queryString,
      method: "post",
      data: object,
      actionName: `Create new ${this.aliasName}`,
    });
  }
}