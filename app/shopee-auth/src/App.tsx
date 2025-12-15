import { BrowserRouter, Routes, Route } from "react-router-dom";
import Authorize from "./pages/Authorize";
import ConnectSuccess from "./pages/ConnectSuccess"
import ShopeeCallback from "./pages/ShopeeCallback"
import Home from "./pages/Home"
import Shop  from "./pages/Shop";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/connect" element={<Authorize />} />
        <Route path="/connect-success" element={<ConnectSuccess />} />
        <Route path="/shopee/callback" element={<ShopeeCallback />} />
         <Route path="/shop" element={<Shop />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
