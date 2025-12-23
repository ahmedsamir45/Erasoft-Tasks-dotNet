# Struct vs Record vs Class in C#

## When to use `struct`

Use **`struct`** for **small, simple value types**.

* Value type (copied by value)
* Usually immutable
* No identity
* Good for performance-critical small data

**Examples:** `Point`, `Color`, `Money`

---

## When to use `record`

Use **`record`** for **data models with value-based equality**.

* Reference type by default
* Immutable by design
* Equality based on data, not reference
* Perfect for DTOs and API models

**Examples:** `StudentDto`, `UserResponse`, `Config`

---

## When to use `record struct`

Use **`record struct`** when you want:

* Value type performance
* Value-based equality
* Small immutable data

**Examples:** `Money`, `Coordinate`

---

## When to use `class`

Use **`class`** for **entities with identity and behavior**.

* Reference type
* Identity matters
* Supports inheritance
* Often mutable

**Examples:** `Student`, `Order`, `Service`

---

## Quick Rule

* **Data only → `record`**
* **Behavior + identity → `class`**
* **Small value → `struct`**
* **Small value + equality → `record struct`**

