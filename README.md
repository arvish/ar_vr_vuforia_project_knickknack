# AR Knick-Knack Trophy (Vuforia + Unity 6) — **ITALIA / ROMA Relic**

A Vuforia MultiTarget AR “knick-knack” built in **Unity 6** that turns a printed cube into a **museum-style trophy**: a Roman artifact stack (temple + amphorae + pugio) crowned by a rotating Earth and bronze “ITALIA” plaque — with live weather/time overlays and dynamic day/night lighting.

> **Core idea:** Make the cube feel like a *relic* — not a demo.  
> **Result:** A clean, readable AR experience with real-time data + cinematic lighting modes.

---

## ✨ Feature Highlights (What you’ll see)

### **Level 1 — AR Knick-Knack (Base Build)**
- **Vuforia MultiTarget tracking** using the provided class cube template (6 faces).
- A vertically composed **Roman/Italy artifact display**:
  - Roman temple centerpiece
  - Amphorae / clay vessels
  - Roman pugio swords
  - Custom Earth globe on top
  - Custom bronze ITALIA plaque
- **Lighting** to make the composition readable and “trophy-like”
- **Ambient audio**: *real bells recorded from Saint Dominica Chapel (Tuscany)*

### **Level 2 — Informational Cube Faces**
Four cube faces display:
- **Location** (e.g., “ROME / ITALY”)
- **Current weather** (via OpenWeather API; auto-refresh interval)
- **Local time in Rome** (timezone-correct)
- **Extra face** (project/scene info)

All faces are styled with **bronze panel backgrounds** and readable text treatment.

### **Level 4 — Automatic Day/Night Behavior**
The AR scene **automatically changes** based on **Rome local time**:
- **Night mode:** strong cyan/blue “relic glow” + rim lighting, dim global light
- **Day mode:** brighter museum lighting + fill light to maintain bronze shine

### **Level 5 — User Interaction (Flip Override)**
Flipping the cube upside down triggers:
- **Temporary day/night override** (inverts L4 for demonstration and interaction)
- **UI visibility toggle** (labels on/off)
- **Globe spin toggle** (slow rotation enabled only during flip mode)

---

## 🧰 Tech Stack
- **Unity:** 6000.3.7f1 (Unity 6 LTS)
- **Vuforia Engine:** (check Package Manager for installed version)
- **Blender:** used for custom models
- **OpenWeather API:** real-time weather
- **TextMeshPro:** cube face text overlays

---

## 🚀 How To Run (Play Mode Demo)
> This project is designed to be run in **Unity Editor Play Mode** using your webcam.

1. Open the project in Unity Hub and launch with Unity **6000.3.7f1**.
2. Open the main scene:
   - `SampleScene` (or `SampleScene_L1_WORKING`, depending on your repo)
3. Press **Play**.
4. Hold up the **printed class cube** to your webcam.
5. Rotate the cube to reveal:
   - the knick-knack trophy stack
   - the 4 informational faces (location, weather, time, extra)
6. **Flip** the cube upside down to trigger L5 interaction behavior.

---

## 🌦️ OpenWeather Setup (IMPORTANT)
This repo does **not** include the API key.

1. Create an OpenWeather API key.
2. In Unity, click the weather TextMeshPro object (or the GameObject that has `weatherAPI.cs`).
3. Paste your key into the script’s Inspector field:
   - `apiKey`
4. Set city/country if desired:
   - `Rome, IT` (default)

**Refresh interval:** weather updates periodically (e.g., every 10 minutes), and can be forced with a manual refresh key if implemented.

> ✅ Tip: Do **not** commit the API key into GitHub.

---

## 🗺️ Project Structure (High-level)
- `MultiTarget/`
  - `KnickKnackRoot/` → the trophy stack (models + custom assets + lights + audio)
  - `L2_Faces/` → the four face anchors + text panels
  - `L4_Controller/` → auto day/night logic (Rome time)
  - `L5_Controller/` → flip interaction logic (override + toggles)

---

## 🧠 Design Notes (HCI / XR Reasoning)
- **Vertical growth**: The knick-knack is intentionally stacked upward to create a strong silhouette and reduce visual clutter on the cube’s top surface.
- **Readable UI faces**: Text panels “grow outward” from cube faces (anchored and offset) to improve legibility while rotating the cube.
- **Lighting as feedback**: L4 provides context (“it’s night in Rome”), while L5 provides *control* (flip to temporarily invert) — enabling both realism and demonstrability.
- **Audio authenticity**: Using a real Tuscany bell recording strengthens presence and personal narrative.

---

## ✅ Completion Summary (Rubric Mapping)
- **L1:** MultiTarget tracking + 3 existing models + 2 custom models + lighting + ambient audio  
- **L2:** 4 faces: location + weather (live API) + Rome time + extra  
- **L4:** Automatic day/night visual changes (Rome time)  
- **L5:** Flip interaction toggles (override + UI + globe spin)  
- **L3:** Not implemented (two simultaneous knick-knacks)

---

## 🧾 Credits / Citations
### Existing Models (3)
- **Ancient Roman Temple 2** — <Publisher HavolkStudio>. *Unity Asset Store*.  
  URL: [https://assetstore.unity.com/packages/3d/environments/historic/ancient-temple-2-74766](https://assetstore.unity.com/packages/3d/environments/historic/ancient-temple-2-74766#description)  
  License: Unity Asset Store EULA (Standard).
- **Amphora / Clay Vases** — <Publisher GVOZDY>. *Unity Asset Store*.  
  URL: [https://assetstore.unity.com/packages/3d/environments/historic/ancient-temple-2-74766](https://assetstore.unity.com/packages/3d/props/interior/ancient-clay-jug-ornate-ceramic-vase-298044)  
  License: Unity Asset Store EULA (Standard).
- **Roman Pugio Sword** — <Publisher Sergi Nicolas>. *Unity Asset Store*.   
  URL: [https://assetstore.unity.com/packages/3d/environments/historic/ancient-temple-2-74766](https://assetstore.unity.com/packages/3d/props/weapons/roman-pugio-19536)  
  License: Unity Asset Store EULA (Standard).

### Custom Models (2) — Blender
- Earth globe (UV sphere + equirectangular map texture)
- Bronze ITALIA plaque (beveled plate + embossed/engraved text)

### Texture
- Earth map texture: ([source link + Attribution 4.0 International (CC BY 4.0)](https://blenderartists.org/t/8k-earth-texture-download-free/1193918))

### Audio
- **Bells of Saint Dominica Chapel, Tuscany** — recorded

### API
- OpenWeather API — current conditions endpoint

---

## 🧪 Troubleshooting
### Vuforia Play Mode camera looks low-res
- Confirm Game view Scale is **1x** and resolution set (e.g., **1920×1080**)
- Ensure Vuforia Play Mode is using the correct **Camera Device**
- Note: Unity Stats FPS can exceed webcam FPS (render loop vs camera capture)

### Weather not updating
- Check API key is set in Inspector
- Test key in browser:
  `https://api.openweathermap.org/data/2.5/weather?q=Rome,IT&appid=KEY&units=metric`

---

## 🙌 Author
**Arvish** — Project built for Virtual / Augmented / Mixed Reality coursework using Unity + Vuforia.
