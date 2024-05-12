
export default function sign_up() {

    return (
        <main className="flex min-h-screen flex-col items-center justify-between p-24">
            <form action={"http://127.0.0.1:8080/user/sign-up"} className="space-y-3">
                <div className="flex-1 rounded-lg px-6 pb-4 pt-8">
                    <h1>Please enter your information below</h1>
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
                            <label htmlFor="name">
                                Username
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="name"
                                    type="name"
                                    name="name"
                                    placeholder="Enter your user name"
                                    required
                                />
                            </div>
                            <label htmlFor="password">
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
                        <button type="submit" className="peer block w-full rounded-md border border-gray-200">
                            Sign up
                        </button>
                    </div>
                </div>
            </form>
        </main>
    );
}