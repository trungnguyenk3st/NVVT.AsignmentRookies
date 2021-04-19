import axios from "axios";
import { host,category } from "../config";
// import commonService from "./commonService";

class cateService {
  getList() {
    return axios({
      url: host + "/" + category,
      method: "get",
      actionName: `Get list Category`,
    });
  }
  edit(id, object) {
    return axios({
      url: host + "/" + category + "/" + id,
      method: "put",
      data: object,
      actionName: `Edit category with ID: ${id}`,
    });
  }

  delete(id) {
    return axios({
      url: host + "/" + category + "/" + id,
      method: "delete",
      actionName: `Delete category with ID: ${id}`,
    });
  }
  create(object) {
    return axios({
      url: host + "/" + category,
      method: "post",
      data: object,
      actionName: `Create new categories`,
    });
  }
}

export default new cateService();