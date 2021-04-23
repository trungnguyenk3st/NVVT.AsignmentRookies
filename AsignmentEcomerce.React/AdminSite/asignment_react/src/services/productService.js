import http from "../httpClient";

class productService {
  pathSer = "products";

  getList(params) {
    return http.get(this.pathSer + this._createQuery(params));
  }

  get(id) {
    return http.get(this.pathSer + "/" + id);
  }

  edit(id, objectEdit) {
    return http.put(this.pathSer + "/" + id, objectEdit);
  }

  delete(id) {
    return http.delete(this.pathSer + "/" + id);
  }

  create(objectNew) {
    return http.post(this.pathSer, objectNew);
  }

  _createQuery(params) {
    if (!params) return "";
    let queryStr = "";
    for (const key in params) {
      if (!params[key]) continue;
      if (queryStr) queryStr += "&&";
      queryStr += key + "=" + params[key];
    }
    return "?" + queryStr;
  }
}

export default new productService();
