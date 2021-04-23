
import axios from "axios";

const instance = axios.create({
  baseURL: "https://trungshop.azurewebsites.net/api",
});

export default instance;