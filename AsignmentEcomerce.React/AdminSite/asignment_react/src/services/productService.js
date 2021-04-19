import axios from "axios";
import { host } from "../config";
export default function orderService(serName = "order", alisName = "Order") {
  return {
    getList: (start, end) =>
      axios({
        url: host + "/" + serName,
        method: "get",
        actionName: "Lấy danh sách " + alisName,
      }),
    get: (id) =>
      axios({
        url: host + "/" + serName + "/" + id,
        method: "get",
      }),
    edit: (id, object) => {
      return axios({
        url: host + "/" + serName + "/" + id,
        method: "post",
        data: object,
        actionName: "chỉnh sửa " + alisName,
      });
    },
  };
}