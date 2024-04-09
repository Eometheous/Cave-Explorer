<h1>How to build the project</h1> 

<h2>Unity (Optional)</h2>
Download Unity Hub from https://unity.com/products/unity-engine
<br>
Activate a free personal licence.
<br>
Download and install Unity 2022.3.20f1 from Unity Hub
<br>
Add and open the Cave Explorer project under /dev/Cave Explorer
<br>
Click the play button on the top middle of the screen to start playing the game. 

For the controls of the game, go to the README under docs/app_users


<h2>Flask</h2>

cd into dev/web_app/flask
<br>
Create a Virtual Python Environment
MacOS: 

`
python3 -m venv .venv`

 `. .venv/bin/activate
 `
 <br>

Windows: 

`
py -3 -m venv .venv
`

`
.venv\Scripts\activate
`

Install flask with `pip install Flask`
<br>
Finally, 
start the server with `python3 -m flask --app app.py run`

<h2>React</h2>

cd into `dev/web_app/react/cave-explorer`
<br>
run `npm run dev`
<br>
click on the url to the local web server
