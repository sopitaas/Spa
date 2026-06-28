
// ==========================================
// CONTADOR DE SÍ/NO EN BIENVENIDA
// ==========================================
document.addEventListener("DOMContentLoaded", () => {
  const nombrePagina = window.location.pathname.split("/").pop();
  if (nombrePagina !== "bienvenida.html" && nombrePagina !== "") return;

  const btnSi = document.querySelector("button[aria-label*='discapacidad visual']");
  const btnNo = document.querySelector("button[aria-label*='no padezco']");

  if (!btnSi || !btnNo) return;

  if (!localStorage.getItem("contadorSi")) localStorage.setItem("contadorSi", "0");
  if (!localStorage.getItem("contadorNo")) localStorage.setItem("contadorNo", "0");

  btnSi.addEventListener("click", () => {
    let actual = parseInt(localStorage.getItem("contadorSi"));
    localStorage.setItem("contadorSi", actual + 1);
  });

  btnNo.addEventListener("click", () => {
    let actual = parseInt(localStorage.getItem("contadorNo"));
    localStorage.setItem("contadorNo", actual + 1);
  });
});
  // --- TOOLTIP PARA EXPERTAS ---
  const expertasImgs = document.querySelectorAll(
    ".expertas-galeria .img-cuadro"
  );
  const infoExpertas = [
    "Valeria cuenta con más de 10 años de experiencia en terapias de masaje y bienestar integral. Está especializada en masajes relajantes, descontracturantes, piedras calientes y reflexología. Su enfoque personalizado y su calidez humana hacen que cada sesión sea una experiencia profunda de relajación y renovación.",
    "Camila es una esteticista profesional con amplia trayectoria en tratamientos faciales. Domina técnicas de limpieza profunda, hidratación, rejuvenecimiento y cuidado de piel sensible. Su compromiso con la belleza natural y el bienestar de sus clientes la convierten en una referente en el área estética del spa.",
  ];

  expertasImgs.forEach((img, index) => {
    const wrapper = document.createElement("div");
    wrapper.style.position = "relative";
    wrapper.style.display = "inline-block";

    const tooltip = document.createElement("div");
    tooltip.classList.add("tooltip-info");
    tooltip.textContent = infoExpertas[index];

    img.parentNode.replaceChild(wrapper, img);
    wrapper.appendChild(img);
    wrapper.appendChild(tooltip);

    wrapper.addEventListener("mouseenter", () => {
      tooltip.classList.add("tooltip-visible");
    });

    wrapper.addEventListener("mouseleave", () => {
      tooltip.classList.remove("tooltip-visible");
    });
  });
  // --- PRESELECCIONAR SERVICIO DESDE URL ---
  function obtenerParametroURL(nombre) {
    const urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(nombre);
  }

  function preseleccionarServicio() {
    const servicioSeleccionado = obtenerParametroURL("servicio");
    const selectServicio = document.getElementById("servicio");

    if (servicioSeleccionado && selectServicio) {
      selectServicio.value = servicioSeleccionado;
      const eventoChange = new Event("change");
      selectServicio.dispatchEvent(eventoChange);
    }
  }

// ==========================================
// AGENDA TU CITA
// ==========================================
document.addEventListener("DOMContentLoaded", () => {
  const formCita = document.getElementById("formCita");
  const selectServicio = document.getElementById("servicio");
  const selectDuracion = document.getElementById("duracion");
  const campoPersonas = document.getElementById("campoPersonas");
  const inputPersonas = document.getElementById("personas");
  const precioFinal = document.getElementById("precioFinal");

  const duracionesPorServicio = {
    "masaje-relajante": ["30 min", "60 min"],
    "masaje-piedras-calientes": ["30 min", "60 min"],
    "masaje-descontracturante": ["30 min", "60 min"],
    "facial-express": ["Individual", "Para dos personas"],
    "facial-profundo": ["Individual", "Para dos personas"],
    "facial-rejuvenecedor": ["Individual", "Para dos personas"],
    "camara-vapor": ["30 min", "60 min"],
    "camara-seca": ["30 min", "60 min"],
    "tina-hidromasaje": ["30 min", "60 min"],
    "promo-mes": ["-"],
    "promo-cumple": ["-"],
    "promo-ritual-relax": ["-"]
  };

  const preciosPorServicio = {
    "masaje-relajante": { "30 min": 50, "60 min": 90 },
    "masaje-piedras-calientes": { "30 min": 65, "60 min": 95 },
    "masaje-descontracturante": { "30 min": 60, "60 min": 80 },
    "facial-express": { "Individual": 89, "Para dos personas": 158 },
    "facial-profundo": { "Individual": 90, "Para dos personas": 160 },
    "facial-rejuvenecedor": { "Individual": 190, "Para dos personas": 360 },
    "camara-vapor": { "30 min": 70, "60 min": 130 },
    "camara-seca": { "30 min": 70, "60 min": 130 },
    "tina-hidromasaje": { "30 min": 80, "60 min": 150 },
    "promo-mes": 160,
    "promo-cumple": 260,
    "promo-ritual-relax": 320
  };

  function actualizarUIPrecioYPersonas() {
    const servicio = selectServicio.value;
    const duracion = selectDuracion.value;
    const personas = parseInt(inputPersonas.value) || 1;
    let total = 0;

    if (servicio === "promo-cumple" || servicio === "promo-ritual-relax") {
      campoPersonas.style.display = "block";
      total = preciosPorServicio[servicio] * personas;
      precioFinal.textContent = `Precio total: S/ ${total.toFixed(2)}`;
      return;
    }

    if (servicio === "promo-mes") {
      campoPersonas.style.display = "none";
      inputPersonas.value = 1;
      precioFinal.textContent = `Precio: S/ ${preciosPorServicio[servicio].toFixed(2)}`;
      return;
    }

    campoPersonas.style.display = "none";
    inputPersonas.value = 1;

    if (preciosPorServicio[servicio] && preciosPorServicio[servicio][duracion]) {
      total = preciosPorServicio[servicio][duracion];
      precioFinal.textContent = `Precio: S/ ${total.toFixed(2)}`;
    } else {
      precioFinal.textContent = "";
    }
  }

  if (selectServicio) {
    selectServicio.addEventListener("change", () => {
      const servicio = selectServicio.value;
      const duraciones = duracionesPorServicio[servicio] || [];
      selectDuracion.innerHTML = "";
      duraciones.forEach((dur) => {
        const option = document.createElement("option");
        option.value = dur;
        option.textContent = dur;
        selectDuracion.appendChild(option);
      });
      actualizarUIPrecioYPersonas();
    });
  }

  if (selectDuracion) {
    selectDuracion.addEventListener("change", actualizarUIPrecioYPersonas);
  }

  if (inputPersonas) {
    inputPersonas.addEventListener("input", actualizarUIPrecioYPersonas);
  }

  if (formCita) {
    formCita.addEventListener("submit", function (e) {
      // e.preventDefault();
      const formData = new FormData(this);
      const datos = Object.fromEntries(formData);

      if (!datos.nombre || !datos.apellido || !datos.fecha || !datos.hora || !datos.servicio || !datos.duracion) {
        alert("Por favor, completa todos los campos.");
        return;
      }

      const hoy = new Date().toISOString().split("T")[0];
      if (datos.fecha < hoy) {
        alert("La fecha seleccionada ya pasó. Elige una futura.");
        return;
      }

      const resumen = `
        <strong>Nombre:</strong> ${datos.nombre} ${datos.apellido}<br>
        <strong>DNI:</strong> ${datos.dni}<br>
        <strong>Fecha:</strong> ${datos.fecha}<br>
        <strong>Hora:</strong> ${datos.hora}<br>
        <strong>Servicio:</strong> ${selectServicio.options[selectServicio.selectedIndex].text}<br>
        <strong>Duración:</strong> ${selectDuracion.options[selectDuracion.selectedIndex].text}<br>
        <strong>Número de personas:</strong> ${datos.personas || 1}
      `;

      document.getElementById("resumenCita").innerHTML = resumen;
      document.getElementById("modalCita").style.display = "block";

      // contador de citas
      let contadorAgenda = parseInt(localStorage.getItem("contadorAgenda") || "0");
      localStorage.setItem("contadorAgenda", contadorAgenda + 1);

      // guardar datos completos
      const nuevaCita = {
        dni: datos.dni,
        nombre: datos.nombre,
        apellido: datos.apellido,
        fecha: datos.fecha,
        hora: datos.hora,
        servicio: datos.servicio,
        duracion: datos.duracion,
        personas: datos.personas || 1,
        origen: "No discapacidad visual" 
      };

      let citasGuardadas = JSON.parse(localStorage.getItem("citasRegistradas")) || [];
      citasGuardadas.push(nuevaCita);
      localStorage.setItem("citasRegistradas", JSON.stringify(citasGuardadas));

      document.getElementById("cerrarModal").addEventListener("click", () => {
        document.getElementById("modalCita").style.display = "none";
      });

      formCita.reset();
      actualizarUIPrecioYPersonas();
    });

    preseleccionarServicio();
  }

  actualizarUIPrecioYPersonas();
});
  // ==========================================
// ATAJO ALT + R PARA ABRIR ADMIN
// ==========================================
document.addEventListener("keydown", function(e) {
  if (e.altKey && e.key.toLowerCase() === "r") {
    e.preventDefault();
    window.location.href = "admin.html";
  }
});
