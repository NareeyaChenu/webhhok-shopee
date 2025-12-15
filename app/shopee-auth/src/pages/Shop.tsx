import { useNavigate } from "react-router-dom";
import { useState } from "react";

export default function Shop() {
  const navigate = useNavigate();

  // Example data
  const shops = [
    {
      id: 1,
      name: "wsis sanbox",
      username: "support@winonafeminine.com",
      status: "connected",
    },
  ];

  return (
    <div style={{ padding: "40px" }}>
      {/* Header */}
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
          marginBottom: "24px",
        }}
      >
        <h1 style={{ fontSize: "28px", fontWeight: "600" }}>My shop</h1>

        <button
          onClick={() => navigate("/connect")}
          style={{
            background: "#3b82f6",
            color: "white",
            padding: "10px 18px",
            borderRadius: "10px",
            border: "none",
            cursor: "pointer",
            display: "flex",
            alignItems: "center",
            gap: "8px",
            fontSize: "15px",
            fontWeight: "500",
            boxShadow: "0 4px 10px rgba(0,0,0,0.1)",
          }}
        >
          <span style={{ fontSize: "18px" }}>＋</span> Create
        </button>
      </div>

      {/* Table */}
      <div
        style={{
          background: "white",
          borderRadius: "12px",
          padding: "20px",
          boxShadow: "0 4px 16px rgba(0,0,0,0.05)",
        }}
      >
        <table style={{ width: "100%", borderCollapse: "collapse" }}>
          <thead>
            <tr style={{ background: "#f3f4f6", textAlign: "left" }}>
              <th style={headCell}>Name</th>
              <th style={headCell}>Username</th>
              <th style={headCell}>Status</th>
              <th style={headCell}>Actions</th>
            </tr>
          </thead>

          <tbody>
            {shops.map((shop) => (
              <tr key={shop.id}>
                <td style={bodyCell}>{shop.name}</td>
                <td style={bodyCell}>{shop.username}</td>

                {/* Status Badge */}
                <td style={bodyCell}>
                  <span
                    style={{
                      background: "#3b82f6",
                      color: "white",
                      padding: "6px 14px",
                      borderRadius: "8px",
                      fontSize: "14px",
                      boxShadow: "0 2px 8px rgba(59,130,246,0.3)",
                    }}
                  >
                    เชื่อมต่อแล้ว
                  </span>
                </td>

                {/* Delete button */}
                <td style={bodyCell}>
                  <button
                    onClick={() => alert("Delete?")}
                    style={{
                      background: "transparent",
                      border: "none",
                      cursor: "pointer",
                      color: "#ef4444",
                      fontSize: "20px",
                    }}
                  >
                    🗑
                  </button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>

        {/* Pagination */}
        <div
          style={{
            marginTop: "16px",
            display: "flex",
            justifyContent: "flex-end",
            gap: "10px",
          }}
        >
          <button style={pageBtn}>◀</button>
          <button style={pageBtn}>▶</button>
        </div>
      </div>
    </div>
  );
}

/* Styles */
const headCell = {
  padding: "14px",
  borderBottom: "1px solid #e5e7eb",
  fontWeight: "600",
};

const bodyCell = {
  padding: "14px",
  borderBottom: "1px solid #f3f4f6",
  fontSize: "15px",
};

const pageBtn = {
  padding: "8px 12px",
  background: "white",
  border: "1px solid #d1d5db",
  borderRadius: "8px",
  cursor: "pointer",
};
