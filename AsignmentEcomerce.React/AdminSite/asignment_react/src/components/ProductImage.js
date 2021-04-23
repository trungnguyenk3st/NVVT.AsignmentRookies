import React from "react";

const productRes = "https://trungshop.azurewebsites.net/";

export default function ProductImage({ src }) {
  return (
    <div>
      {!src ? (
        <span className="text-secondary">No image</span>
      ) : (
        <img width={100} src={productRes + src} alt="Product" />
      )}
    </div>
  );
}