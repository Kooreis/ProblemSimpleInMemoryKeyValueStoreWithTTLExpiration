# Question: How do you implement a simple in-memory key-value store with TTL expiration? JavaScript Summary

The JavaScript code provided is a simple implementation of an in-memory key-value store with Time-To-Live (TTL) expiration. The code defines a class named `KeyValueStore` with a constructor that initializes an empty object `store` to hold the key-value pairs. The class has two methods: `set` and `get`. The `set` method is used to add a key-value pair to the store and set a TTL for the pair. If the key already exists in the store, the method clears the existing timeout before setting the new value and starting a new timeout. The TTL is implemented using JavaScript's `setTimeout` function, which deletes the key-value pair from the store after the specified TTL has passed. The `get` method is used to retrieve the value associated with a given key from the store. If the key does not exist in the store, the method returns `null`. This implementation provides a simple and efficient way to manage key-value pairs with TTL expiration in memory.

---

# TypeScript Differences

The TypeScript version of the solution is very similar to the JavaScript version, with the main difference being the addition of type annotations. TypeScript is a statically typed superset of JavaScript, which means it adds static types to the language. This can help catch errors at compile time rather than at runtime.

In the TypeScript version, the `store` property is explicitly typed as an object with string keys and values that are objects containing a `value` of any type and a `timeoutId` of type `NodeJS.Timeout`. This provides a clear definition of what the `store` object should look like.

The `set` method has type annotations for its parameters: `key` is a string, `value` can be any type, and `ttl` is a number. This ensures that the method is always called with the correct types of arguments.

The `get` method has a type annotation for its `key` parameter, indicating that it should always be a string.

Overall, the TypeScript version provides the same functionality as the JavaScript version, but with the added benefit of static typing to help prevent type-related errors.

---

# C++ Differences

The C++ version of the solution also creates a `KeyValueStore` class with a `store` object (in this case, an `unordered_map`) to hold the key-value pairs. The `put` method sets a key-value pair in the store and starts a new thread that sleeps for the specified TTL (time to live) duration and then erases the key-value pair from the store. If the key already exists in the store, the old value is simply overwritten and the old thread (if it exists) will not be able to erase the key-value pair because it will not find it in the store. The `get` method retrieves the value for a key from the store, or throws a `runtime_error` if the key does not exist.

The main differences between the JavaScript and C++ versions are:

1. Concurrency: In JavaScript, `setTimeout` is used to schedule the deletion of the key-value pair after the TTL. In C++, a new thread is created for each key-value pair that sleeps for the TTL duration and then erases the key-value pair. This means that the C++ version can handle multiple key-value pairs with different TTLs concurrently.

2. Error Handling: In JavaScript, if a key does not exist in the store, the `get` method returns `null`. In C++, if a key does not exist in the store, the `get` method throws a `runtime_error`.

3. Synchronization: In the C++ version, a `mutex` is used to synchronize access to the `store` to prevent race conditions when multiple threads are accessing and modifying the `store` at the same time. JavaScript is single-threaded, so it does not need to worry about synchronization.

4. Type Safety: In JavaScript, keys and values can be any type. In the C++ version, keys and values are both `int`.

5. Memory Management: In JavaScript, memory is managed automatically by the garbage collector. In C++, the programmer has to manage memory manually. In this case, the threads are detached, which means that their resources will be released automatically when they finish execution.

---
