import { BrowserRouter as Router } from "react-router-dom";
import Header from "./components/Header";
import Navigate from "./components/Navigate";
import PageLayout from "./containers/PageLayout";
import Routes from "./routes";

function App() {
  return (
    <Router>
      <PageLayout header={<Header />} nav={<Navigate />} content={<Routes />} />
    </Router>
  );
}