document.addEventListener("DOMContentLoaded", () => {
    const name = document.getElementById("name");
    const phone = document.getElementById("phone");
    const content = document.getElementById("content");
    const submit = document.getElementById("submit");

    submit.addEventListener("click", (e) => {
        const data = {
            name: name.value,
            phone: phone.value,
            content: content.value,
        };

        if (data.name && data.phone && data.content) {
            postGoogle(data);
        } else {
            alert("Vui lòng điền đầy đủ thông tin.");
        }
    });

    async function postGoogle(data) {
        const formURL = "https://docs.google.com/forms/d/e/1FAIpQLSdXQ3i5mPcPXZGpVtSuvUQGt2WWwsHQwTtY_Q0-lGimf1csiQ/formResponse";
        const formData = new FormData();
        formData.append("entry.1603168185", data.name); 
        formData.append("entry.997553103", data.phone); 
        formData.append("entry.1414450673", data.content); 

        try {
            await fetch(formURL, {
                method: "POST",
                body: formData,
                mode: "no-cors"
            });
            alert("Thông tin liên hệ đã được gửi.");
        } catch (error) {
            alert("Có lỗi xảy ra khi gửi thông tin.");
            console.error("Error:", error);
        }
    }
});
