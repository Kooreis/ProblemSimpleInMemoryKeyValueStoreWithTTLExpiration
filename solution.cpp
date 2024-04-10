```cpp
#include <iostream>
#include <unordered_map>
#include <thread>
#include <chrono>

class KeyValueStore {
public:
    void put(int key, int value, int ttl) {
        std::lock_guard<std::mutex> lock(mtx);
        store[key] = value;
        auto it = store.find(key);
        std::thread([this, it, ttl]() {
            std::this_thread::sleep_for(std::chrono::seconds(ttl));
            std::lock_guard<std::mutex> lock(mtx);
            if (it != store.end()) {
                store.erase(it);
            }
        }).detach();
    }

    int get(int key) {
        std::lock_guard<std::mutex> lock(mtx);
        if (store.find(key) != store.end()) {
            return store[key];
        } else {
            throw std::runtime_error("Key not found");
        }
    }

private:
    std::unordered_map<int, int> store;
    std::mutex mtx;
};

int main() {
    KeyValueStore kv;
    kv.put(1, 100, 5);
    try {
        std::cout << kv.get(1) << std::endl;
    } catch (const std::exception& e) {
        std::cout << e.what() << std::endl;
    }
    std::this_thread::sleep_for(std::chrono::seconds(6));
    try {
        std::cout << kv.get(1) << std::endl;
    } catch (const std::exception& e) {
        std::cout << e.what() << std::endl;
    }
    return 0;
}
```