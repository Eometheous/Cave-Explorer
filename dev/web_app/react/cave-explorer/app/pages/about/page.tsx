import Head from 'next/head';

export default function About() {
    return (
        <div>
            <Head>
                <title>About Cave Explorer</title>
                <meta name="description" content="Learn more about the Cave Explorer game." />
                <link rel="icon" href="/favicon.ico" />
            </Head>

            <main className="flex flex-col items-center justify-center min-h-screen p-6">
                <h1 className="text-3xl font-bold mb-4">About Cave Explorer</h1>
                <p className="text-lg mb-4">
                    Cave Explorer is a simple sliding puzzle game where the objective is to move a square piece from the starting slot to the end slot. The game consists of a square grid where the user interacts by clicking and dragging the white square to the top of the level.
                </p>
                <p className="text-lg">
                    As the player progresses, the game will gradually introduce more obstacles, such as blocks blocking the user's path, making the puzzles increasingly challenging.
                </p>
            </main>
        </div>
    );
}