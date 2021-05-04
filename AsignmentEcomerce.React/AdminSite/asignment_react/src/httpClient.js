
import axios from "axios";

const instance = axios.create({
  baseURL: "https://backende069e98663574dd58d6fe43c48b63058.azurewebsites.net/api",
});

export default instance;