export default function ConnectSuccess() {
  return (
    <div
      style={{
        minHeight: "100vh",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
        background: "linear-gradient(135deg, #f0f7ff 0%, #dff1ff 100%)"
      }}
    >
      <div
        style={{
          background: "white",
          padding: "40px 50px",
          borderRadius: "16px",
          boxShadow: "0 10px 25px rgba(0,0,0,0.08)",
          textAlign: "center",
          maxWidth: "420px",
          animation: "fadeIn 0.6s ease"
        }}
      >
        <div
          style={{
            fontSize: "64px",
            marginBottom: "10px"
          }}
        >
          🎉
        </div>

        <h1
          style={{
            fontSize: "26px",
            marginBottom: "10px",
            color: "#1f5fbf",
            fontWeight: "600"
          }}
        >
          Shopee Connected Successfully!
        </h1>

        <p
          style={{
            fontSize: "16px",
            marginBottom: "30px",
            color: "#333"
          }}
        >
          Your shop is now linked and ready to use.
        </p>

        <button
          onClick={() => (window.location.href = "/")}
          style={{
            background: "#007bff",
            color: "white",
            border: "none",
            padding: "12px 20px",
            borderRadius: "8px",
            cursor: "pointer",
            fontSize: "16px",
            fontWeight: "500",
            transition: "0.2s",
          }}
          onMouseOver={e => (e.currentTarget.style.background = "#005fcc")}
          onMouseOut={e => (e.currentTarget.style.background = "#007bff")}
        >
          Go to Dashboard
        </button>
      </div>
    </div>
  );
}
