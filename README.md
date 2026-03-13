# AR Knick-Knack Trophy (Vuforia + Unity 6) — **ITALIA / ROMA Relic**
**Author:** Arvish Pandey
**Course:** Virtual / Augmented / Mixed Reality (Unity + Vuforia)  
**Repo:** *[(Github Repo)](https://github.com/arvish/ar_vr_vuforia_project_knickknack)*  

A Vuforia **MultiTarget** AR “knick-knack” built in **Unity 6** that turns a printed cube into a **museum-style relic/trophy**: a Roman artifact stack (temple + amphorae + pugio) crowned by a rotating Earth and bronze “ITALIA” plaque — with live **weather/time** overlays and dynamic **day/night** lighting.

> **Core idea:** Make the cube feel like a *relic*, not a demo.  
> **Result:** A readable, trophy-grade AR experience with real-time data + cinematic lighting + a simple interaction mode.

---

## 🎥 Demo Video 
**Demo link:** *(TODO: add YouTube/portfolio video link)* 

---

## Table of Contents
- [Motivation & Chosen Location](#motivation--chosen-location)
- [Design](#design)
- [Process](#process)
- [Challenges & Future Work](#challenges--future-work)
- [AI Use & Collaboration](#ai-use--collaboration)
- [How To Run](#how-to-run)
- [OpenWeather Setup](#openweather-setup)
- [Controls](#controls)
- [Project Structure](#project-structure)
- [Credits / Citations](#credits--citations)

---

## Motivation & Chosen Location
This project is a personal AR “souvenir relic” built around **Italy**—specifically **Rome**—as a way to compress a place into a handheld object you can “summon” anywhere.

My Italy trip left a strong impression because it wasn’t just a study abroad; it was a lens on how **tradition and technology** can coexist: craft, history, and identity, but also modern engineering and innovation. A major inspiration was my exposure to luxury innovation thinking (e.g., the kind of “craft + systems” mindset embodied by iconic Italian engineering culture like **Pagani**) and the idea that a place can be represented as a curated stack of symbols, not a literal environment.

So instead of building a full “game level,” I built a **museum trophy**:
- **Roman artifacts** (temple, amphorae, pugio)
- a **global layer** (Earth globe) to signal “place in the world”
- a **nameplate** (“ITALIA” plaque) to make it feel like a physical collectible
- **real-time context** (weather + Rome local time) to make it *alive*
- **lighting modes** to sell “time-of-day presence”

---

## Design
### Level 1 — The knick-knack as a vertical “relic stack”
The knick-knack grows **vertically** from the cube base so the silhouette reads instantly and the top surface stays clean. It’s not physically-to-scale on purpose — it’s a **curated display** (like a trophy shelf).

**Visual elements**
- **Roman Temple (existing model):** centerpiece structure to anchor “Rome”
- **Amphora / Clay Vases (existing model):** flanking props for symmetry and “antiquity”
- **Roman Pugio Sword(s) (existing model):** dramatic artifact layer above the temple
- **Earth Globe (custom Blender model):** a UV sphere with an equirectangular Earth texture (fast + realistic)
- **“ITALIA” bronze plaque (custom Blender model):** beveled plaque with embossed letters and bronze material

**Ambient audio**
- Real bells recorded from **Saint Dominica Chapel (Tuscany)** — used as looping ambience to add presence and personal authenticity.

#### Screenshots 
**Figure 1 — Full L1 relic stack anchored on the cube**  
*(TODO: add image — show cube in hand + full trophy stack visible)*  
`![L1 relic stack anchored on cube](docs/images/fig1_l1_relic_stack.jpg)`

**Figure 2 — Close-up of the custom Earth globe + ITALIA plaque**  
*(TODO: add image — show globe mapping + bronze plaque readability)*  
`![Custom globe + plaque](docs/images/fig2_globe_plaque_closeup.jpg)`

---

### Level 2 — Informational faces (floating, face-normal text)
Level 2 adds four cube faces that display context:
- **Location** (Rome, Italy)
- **Current weather** (OpenWeather API, periodic refresh)
- **Local time** (Rome timezone)
- **Extra face** (simple project info / status)

I designed the text to “grow outward” normal to each face, so it feels like a floating label anchored to the cube, not HUD spam.

I also added bronze background panels to improve readability. By the end, the cube reads like a **bronze relic**—a trophy form factor—while still using the printed cube for tracking.

#### Screenshots
**Figure 3 — L2 faces visible (Location / Weather / Time / Extra)**  
*(TODO: add image — show at least 3 faces visible through rotation)*  
`![L2 faces](docs/images/fig3_l2_faces.jpg)`

**Figure 4 — Close-up of a single face panel (readability + styling)**  
*(TODO: add image — show TMP outline + bronze panel behind text)*  
`![Face panel close-up](docs/images/fig4_face_panel_closeup.jpg)`

---

### Level 4 — Automatic day/night behavior (Rome local time)
This is where the project becomes “alive”:
- The scene automatically switches between **Day** and **Night** based on **Rome local time**.

**Day mode (readability + bronze shine)**
- brighter global lighting
- added a **fill light** so the bronze panels don’t require constant cube angling to catch highlights

**Night mode (strong effect)**
- dim global light
- enabled **NightGlowLight** (cyan/blue near the globe)
- enabled **NightRimLight** (rim highlight to separate silhouette from background)

#### Screenshots 
**Figure 5 — Night mode (Rome night): glow + rim lighting clearly visible**  
*(TODO: add image — show cyan glow + rim effect)*  
`![Night mode](docs/images/fig5_night_mode.jpg)`

**Figure 6 — Day mode (forced or auto): brighter museum lighting + fill**  
*(TODO: add image — show day brightness and bronze readability)*  
`![Day mode](docs/images/fig6_day_mode.jpg)`

---

### Level 5 — User interaction (Flip Override + Globe Spin)
User action: **flip the cube upside down** to trigger a mode.

When flipped:
- temporarily **inverts** the L4 day/night behavior (makes demo easy and makes L4 “sellable”)
- toggles **UI faces** on/off (clean “museum mode” vs “data mode”)
- toggles **globe spin** on/off (simple but high signal)

#### Screenshots 
**Figure 7 — L5 flip mode: UI hidden + globe spinning**  
*(TODO: add image — show spin & UI state clearly)*  
`![Flip mode](docs/images/fig7_flip_mode.jpg)`

---

## Process
### How I built it (high-level)
1. **Vuforia MultiTarget setup**
   - Created a MultiTarget database from the provided cube face images.
   - Imported `.xml`/`.dat` database into `StreamingAssets/Vuforia`.
   - Confirmed stable tracking in Unity Play Mode (webcam).

2. **Scene composition**
   - Built the knick-knack stack under a root object so everything moves as a unit.
   - Kept a consistent “trophy silhouette” with vertical stacking.

3. **Custom Blender models**
   - Earth: UV Sphere + Earth map texture (equirectangular) → FBX export → Unity material.
   - ITALIA plaque: beveled plate + embossed text → FBX export → bronze material in Unity.

4. **Live data + time**
   - Weather: OpenWeather “current weather” endpoint → updates on an interval.
   - Time: Rome timezone conversion → updates every second on the face panel.

5. **Behavior layers**
   - L4: auto day/night lighting based on Rome local time.
   - L5: cube flip toggles temporary override + UI + globe spin.

### Code organization (how it’s structured)
My scripts are intentionally modular (one job per script):
- `weatherAPI.cs` — fetch weather and update weather face TMP text
- `timeAPI.cs` — compute Rome local time and update time face TMP text
- `DayNightL4.cs` — auto day/night + night glow/rim + day fill
- `FlipToggleL5.cs` — flip detection and toggles (including temporary override)
- `SlowSpin.cs` — simple rotation for the globe (enabled/disabled via L5)

> **Where to see it:** *(link [here](https://github.com/arvish/ar_vr_vuforia_project_knickknack/tree/main/Assets/KnickKnack/UsedAssets/Scripts))*

---

## Challenges & Future Work
### Challenges (what I struggled with)
- **Vuforia initialization / play mode quirks:** getting stable editor play mode and consistent camera behavior required careful setup.
- **Camera resolution limitations:** even with a capable webcam, Vuforia Play Mode may choose conservative resolutions.
- **Asset stability:** one third-party asset pack introduced scripting/import errors and had to be replaced.
- **Readable face text:** TextMeshPro scaling and face alignment took iteration (face-normal “growth” + styling).
- **Balancing realism vs display logic:** this isn’t a physical-scale diorama; it’s a curated relic stack, so scale choices were made for visibility.

### Future work (what I’d do with more time)
- **Level 3:** multi-knick-knack / multiple tracked objects simultaneously
- **Mobile build:** deploy to phone for more natural AR interaction and better camera control
- **Weather-reactive VFX:** rain/fog/cloud particles triggered by real weather conditions
- **Better typography & UI polish:** improved fonts, consistent margins, adaptive text scaling
- **Post-processing (optional):** subtle bloom for night glow and relic shine

---

## AI Use & Collaboration
### Use of AI (what I used it for)
I used AI (ChatGPT) as a **resource guru + debugging assistant**:
- turning rubric requirements into concrete Unity steps
- locating functionalities in Blender and Unity/Vuforia given how I new I was to them
- troubleshooting Unity/Vuforia edge cases and workflow problems

---

## How To Run
> This project is designed to run in **Unity Editor Play Mode** using your webcam.

1. Open the project in Unity Hub using **Unity 6000.3.7f1**.
2. Open the main scene:
   - `SampleScene` 
3. Add API Keys and then press **Play**
4. Hold up the **printed class cube** to your webcam.
5. Rotate cube to view each face and the knick-knack stack.
6. Flip cube upside down to trigger L5 behavior.

---

## OpenWeather Setup
This repo does **not** include the API key.

1. Create an OpenWeather API key.
2. In Unity, select the TMP object that has `weatherAPI.cs`.
3. Paste your key into the Inspector field:
   - `apiKey`
4. Set:
   - `city = Rome`
   - `countryCode = IT`
   - refresh interval as desired

**Endpoint used:** OpenWeather current conditions.

---

## Controls
- **Rotate cube:** reveal faces + see tracking stability
- **Flip cube upside down:** triggers L5 override mode (temporary invert + UI toggle + globe spin)

---

## Project Structure
High-level runtime structure in Hierarchy:
- `MultiTarget/`
  - `KnickKnackRoot/` → models + custom assets + lights + ambient audio
  - `L2_Faces/` → face anchors + TMP text (and bronze panels)
  - `L4_Controller/` → day/night logic (Rome time)
  - `L5_Controller/` → flip interaction logic (override + toggles)

---

## Credits / Citations
### Unity Asset Store (Existing Models)

- **Ancient Roman Temple 2** — *Publisher: HavolkStudio*. *Unity Asset Store*.   
  URL: https://assetstore.unity.com/packages/3d/environments/historic/ancient-temple-2-74766  
  License: Unity Asset Store EULA (Standard).

- **Ancient Clay Jug / Ornate Ceramic Vase** — *Publisher: GVOZDY*. *Unity Asset Store*.  
  URL: https://assetstore.unity.com/packages/3d/props/interior/ancient-clay-jug-ornate-ceramic-vase-298044  
  License: Unity Asset Store EULA (Standard).

- **Roman Pugio** — *Publisher: Sergi Nicolas*. *Unity Asset Store*.  
  URL: https://assetstore.unity.com/packages/3d/props/weapons/roman-pugio-19536  
  License: Unity Asset Store EULA (Standard).

### Custom Models (Blender)
- Earth globe (UV sphere + equirectangular Earth map texture)
- Bronze ITALIA plaque (beveled plate + embossed text)

### Texture
- Earth map texture source: *([source link + Attribution 4.0 International (CC BY 4.0)](https://blenderartists.org/t/8k-earth-texture-download-free/1193918))*  

### Audio
- **Bells of Saint Dominica Chapel, Tuscany** — recorded. Used as looping ambient sound.

### API / Libraries
- OpenWeather API — current conditions endpoint  
  https://openweathermap.org/current
- TextMeshPro (Unity Package)

---

## 🙌 Author
**Arvish Pandey** — built in Unity + Vuforia as a portfolio-grade AR artifact project.
