<h1>How to build the project</h1> 

<h2>Unity (Optional)</h2>
Download Unity Hub from https://unity.com/products/unity-engine

Activate a free personal licence.

Download and install Unity 2022.3.20f1 from Unity Hub

Add and open the Cave Explorer project under /dev/Cave Explorer

Click the play button on the top middle of the screen to start playing the game. 

For the controls of the game, go to the README under docs/app_users


<h2>Flask (Skip for now)</h2>

1. Open another terminal window to run the flask server

2. cd into `dev/web_app/flask`

3. Create a Virtual Python Environment (Optional)

    MacOS:

       python3 -m venv .venv

       . .venv/bin/activate
 

    Windows:

        py -3 -m venv .venv

        .venv\Scripts\activate


5. Install flask with `pip install Flask`

6. Finally, start the server with `python3 -m flask --app app.py run`

<h2>React</h2>

1. Open another terminal window to run the react server

2. cd into `dev/web_app/react/cave-explorer`

3. run `npm run dev`

4. click on the url to the local web server
