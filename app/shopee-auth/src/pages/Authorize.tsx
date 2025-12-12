import { useState } from "react";
import axios from "axios";

export default function Authorize() {
  const [loading, setLoading] = useState(false);

  const handleConnect = async () => {
    setLoading(true);

    const redirectUrl = "https://vulture-capital-hippo.ngrok-free.app/shopee/callback";
    const timestamp = Math.floor(Date.now() / 1000);

    try {
      const res = await axios.get(
        "http://localhost:5205/api/shopee/v1/authorize-url",
        {
          params: { redirect_url: redirectUrl, timestamp },
        }
      );

      const { authorizeUrl } = res.data;
      window.location.href = authorizeUrl;
    } catch (err) {
      console.error("Error fetching authorize URL:", err);
      alert("Cannot connect to Shopee.");
    }

    setLoading(false);
  };

  return (
    <div
      style={{
        minHeight: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        background: "linear-gradient(135deg, #fff7f3, #ffe6db)",
      }}
    >
      <div
        style={{
          background: "white",
          padding: "50px 60px",
          borderRadius: "16px",
          maxWidth: "480px",
          textAlign: "center",
          boxShadow: "0 10px 25px rgba(0,0,0,0.1)",
          animation: "fadeIn 0.5s ease",
        }}
      >
        {/* Shopee Icon */}
        <div style={{ fontSize: "60px", marginBottom: 20 }}>🛍️</div>

        <h1
          style={{
            fontSize: "28px",
            fontWeight: 600,
            marginBottom: "10px",
            color: "#ef4b23",
          }}
        >
          Connect Your Shopee Shop
        </h1>

        <p style={{ color: "#777", marginBottom: "30px", fontSize: "16px" }}>
          Link your Shopee store to enable seamless integrations.
        </p>

        <button
          onClick={handleConnect}
          disabled={loading}
          style={{
            background: loading ? "#e54a22cc" : "#ef4b23",
            color: "white",
            padding: "14px 22px",
            border: "none",
            width: "100%",
            borderRadius: "8px",
            fontSize: "18px",
            fontWeight: "500",
            cursor: loading ? "not-allowed" : "pointer",
            transition: "0.2s",
            boxShadow: "0 4px 12px rgba(239,75,35,0.3)",
          }}
          onMouseOver={(e) =>
            !loading &&
            (e.currentTarget.style.background = "#d93f1c")
          }
          onMouseOut={(e) =>
            !loading &&
            (e.currentTarget.style.background = "#ef4b23")
          }
        >
          {loading ? "Generating link..." : "Connect to Shopee"}
        </button>

        {loading && (
          <div style={{ marginTop: 20, fontSize: 16, color: "#555" }}>
            🔄 Preparing secure connection...
          </div>
        )}
      </div>
    </div>
  );
}
