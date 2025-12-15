import { useNavigate } from "react-router-dom";

export default function Home() {
  const navigate = useNavigate();

  return (
    <div style={{ display: "flex", height: "100vh", background: "#f7f9fc" }}>
      
      {/* Sidebar */}
      <div
        style={{
          width: "240px",
          background: "#1f2937",
          color: "white",
          padding: "20px 0",
          display: "flex",
          flexDirection: "column",
          gap: "10px",
        }}
      >
        <h2 style={{ marginLeft: 20 }}>Menu</h2>

        <button
          onClick={() => navigate("/shop")}
          style={{
            padding: "12px 20px",
            textAlign: "left",
            background: "transparent",
            color: "white",
            border: "none",
            cursor: "pointer",
            fontSize: "16px",
          }}
          onMouseOver={(e) => (e.currentTarget.style.background = "#374151")}
          onMouseOut={(e) => (e.currentTarget.style.background = "transparent")}
        >
          🛍 Shop
        </button>

        <button
          style={{
            padding: "12px 20px",
            textAlign: "left",
            background: "transparent",
            color: "white",
            border: "none",
            cursor: "pointer",
            fontSize: "16px",
          }}
          onMouseOver={(e) => (e.currentTarget.style.background = "#374151")}
          onMouseOut={(e) => (e.currentTarget.style.background = "transparent")}
        >
          ⚙ Settings
        </button>
      </div>

      {/* Main Page Content */}
      <div style={{ flex: 1, padding: "40px" }}>
        <h1>Welcome</h1>
        <p>Select a menu item from the sidebar.</p>
      </div>
    </div>
  );
}
