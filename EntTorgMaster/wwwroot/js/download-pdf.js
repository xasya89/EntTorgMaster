﻿function jsDownloadFile(filename, content) {
    const file = new File([content], filename, { type: "application/octet-stream" });
    const exportUrl = URL.createObjectURL(file);

    // Create the <a> element and click on it
    const a = document.createElement("a");
    document.body.appendChild(a);
    a.href = exportUrl;
    a.download = filename;
    a.target = "_self";
    a.click();

    // We don't need to keep the object url, let's release the memory
    URL.revokeObjectURL(exportUrl);
}