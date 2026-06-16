
---
## ✅ Requisitos previos
Antes de empezar, asegúrate de tener instalado:
- [.NET SDK 8+](https://dotnet.microsoft.com/download)
- [MySQL Server 8+](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/) *(recomendado)*
- [Git](https://git-scm.com/downloads)
- Visual Studio 2022 o VS Code
---

## 📥 Paso 1 — Clonar el repositorio
Abre una terminal y ejecuta:
```bash
git clone https://github.com/sopitaas/Spa.git
cd Spa
```
---

## 🗄️ Paso 2 — Configurar la base de datos
1. Abre **MySQL Workbench**
2. Ve a `Server` → `Data Import`
3. Selecciona **"Import from Self-Contained File"**
4. Elige el archivo `spa_db.sql` que te compartió tu compañera
5. En **"Default Schema to be Imported To"**, escribe: `spa_db`
6. Haz clic en **"Start Import"**
---

## ⚙️ Paso 3 — Configurar la conexión a la base de datos
Abre el archivo `appsettings.json` y edita la cadena de conexión con **tus propios datos de MySQL**:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=spa_db;User=root;Password=TU_PASSWORD_AQUI;"
}
```
> ⚠️ Reemplaza `TU_PASSWORD_AQUI` con la contraseña de tu MySQL local.
---
## ▶️ Paso 4 — Ejecutar el proyecto
**Opción A — Desde la terminal:**
```bash
dotnet restore
dotnet run
```
**Opción B — Desde Visual Studio:**
1. Abre el archivo `Spa.csproj` o la carpeta en Visual Studio 2022
2. Presiona **F5** o el botón ▶️ **Run**
El proyecto estará disponible en: `https://localhost:5001` o `http://localhost:5000`
---

## 🔄 Cómo subir tus cambios al repositorio
Cuando hagas cambios en el código y quieras subirlos:
```bash
# 1. Ver qué archivos cambiaste
git status
# 2. Agregar los cambios
git add .
# 3. Hacer commit con un mensaje descriptivo
git commit -m "Descripción de lo que hiciste"
# 4. Subir al repositorio
git push
```

### Antes de subir, asegúrate de traer los cambios más recientes de tus compañeros:
```bash
# Traer cambios del repositorio antes de subir los tuyos
git pull
git push
```
> ⚠️ **Importante:** Nunca subas tu contraseña de MySQL. El archivo `appsettings.json` debe tener datos genéricos antes de hacer push.
---

## ❓ Problemas comunes
| Problema | Solución |
|----------|----------|
| Error de conexión a BD | Verifica tu contraseña en `appsettings.json` |
| Puerto ocupado | Cambia el puerto en `launchSettings.json` |
| `dotnet` no reconocido | Instala el .NET SDK y reinicia la terminal |
| Error al importar `.sql` | Crea primero el schema `spa_db` en Workbench |