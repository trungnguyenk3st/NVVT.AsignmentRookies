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
    var fromDATA = new FormData();
    for (const key in objectEdit) {
      fromDATA.append(key,objectEdit[key]);
    }
    console.log(fromDATA)
    return http.put(this.pathSer + "/" + id, fromDATA,{
      headers:{
        'Content-Type': 'multipart/form-data'
      }
    });
  }

  delete(id) {
    return http.delete(this.pathSer + "/" + id);
  }

  create(objectNew) {
    var fromDATA = new FormData();
    for (const key in objectNew) {
      fromDATA.append(key,objectNew[key]);
    }
    // console.log(fromDATA)
    // console.log(objectNew)
   return http.post(this.pathSer,fromDATA,{
    headers:{
      'Content-Type': 'multipart/form-data'
    }
  });
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
