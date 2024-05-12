export default function login() {
    return (
        <main className="flex min-h-screen flex-col items-center justify-between p-24">
            <form action="/api/old-login" className="space-y-3">
                <div className="flex-1 rounded-lg px-6 pb-4 pt-8">
                    <h1>Please log in to continue.</h1>
                    <div className="w-full">
                        <div>
                            <label htmlFor="email">
                                Email
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="email"
                                    type="email"
                                    name="email"
                                    placeholder="Enter your email address"
                                    required
                                />
                            </div>
                            <label htmlFor="email">
                                Password
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="password"
                                    type="password"
                                    name="password"
                                    placeholder="Enter your password"
                                    required
                                />
                            </div>
                        </div>
                        <button className="peer block w-full rounded-md border border-gray-200">
                            Log In
                        </button>
                    </div>
                </div>
            </form>
        </main>
    );
}