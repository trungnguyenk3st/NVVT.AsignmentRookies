
import axios from "axios";

const instance = axios.create({
  baseURL: "https://localhost:44342/api",
});

export default instance;