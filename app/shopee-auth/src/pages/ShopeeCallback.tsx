import { useEffect, useState } from "react";
import axios from "axios";
import { useSearchParams, useNavigate } from "react-router-dom";

export default function ShopeeCallback() {
  const [status, setStatus] = useState("Processing...");
  const [loading, setLoading] = useState(false);
  const [searchParams] = useSearchParams();
  const navigate = useNavigate();

  useEffect(() => {
    const code = searchParams.get("code");
    const shopId = searchParams.get("shop_id");
    const mainAccountId = searchParams.get("main_account_id");

    if (!code || !shopId) {
      setStatus("Invalid callback data");
      return;
    }

    const fetchToken = async () => {
      setLoading(true);

      try {
        const response = await axios.post(
          "http://localhost:5205/api/shopee/v1/get-token",
          {
            code,
            shop_id: shopId,
            main_account_id: mainAccountId
          }
        );

        if (response.data.success) {
          navigate("/connect-success");
        } else {
          setStatus("Failed to connect.");
        }
      } catch (err) {
        console.error(err);
        setStatus("Error during connection.");
      } finally {
        setLoading(false);
      }
    };

    fetchToken();
  }, [navigate, searchParams]);

  return (
    <div style={{ padding: 40, textAlign: "center" }}>
      <h1>{status}</h1>

      {loading && (
        <div style={{ marginTop: 20, fontSize: 20 }}>
          <span className="loader"></span>
          <p>Connecting to Shopee...</p>
        </div>
      )}
    </div>
  );
}
