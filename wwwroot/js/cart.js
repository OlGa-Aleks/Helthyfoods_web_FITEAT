document.addEventListener("DOMContentLoaded", function () {
    const expectedCount = 6;
    let offset = parseInt(document.getElementById("load-more")?.getAttribute("data-offset") || "6", 10);
    let currentMinPrice = null;
    let currentMaxPrice = null;
    let currentMinCalories = null;
    let currentMaxCalories = null;
    let currentSelectedMeals = [];
    let currentSelectedDiets = [];
    let isFiltering = false;

    // Добавление товара – выполняется только если элемент существует
    //const dishesRow = document.getElementById("dishes-row");
    //if (dishesRow) {
    //    dishesRow.addEventListener("click", function (e) {
    //        if (e.target && e.target.classList.contains("add-to-cart")) {
    //            const productId = e.target.getAttribute("data-product-id");
    //            if (productId) {
    //                addToCart(productId);
    //            }
    //        }
    //    });
    //}
    // Обработчик добавления товара для кнопок на каталоге и детальной странице.
    // Используем делегирование событий на документе для универсальности.
    document.addEventListener("click", function (e) {
        if (e.target && (e.target.classList.contains("add-to-cart") || e.target.classList.contains("add-to-cart-cartfood"))) {
            const productId = e.target.getAttribute("data-product-id");
            if (productId) {
                addToCart(productId);
            }
        }
    });

    
    function showModal(message, linkText, linkUrl) {
        let modal = document.getElementById("cartModal");
        if (!modal) {
            modal = document.createElement("div");
            modal.id = "cartModal";
            modal.classList.add("modal", "fade");
            modal.tabIndex = "-1";
            modal.setAttribute("role", "dialog");
            modal.innerHTML = `
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="cartModalLabel">Корзина</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Закрыть">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <p>${message}</p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-primary" onclick="window.location.href='${linkUrl}'">${linkText}</button>
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">ОК</button>
                        </div>
                    </div>
                </div>
            `;
            document.body.appendChild(modal);
        } else {
            modal.querySelector(".modal-body").innerHTML = message;
            const modalLink = modal.querySelector(".btn-primary");
            modalLink.textContent = linkText;
            modalLink.setAttribute("href", linkUrl);
        }
        $("#cartModal").modal("show");
    }

    function addToCart(productId) {
        fetch("/Cart/AddToCart", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ dishId: productId })
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    updateButtonState();
                    showModal("Товар добавлен в корзину", "Перейти в корзину", data.cartUrl);
                } else {
                    alert("Ошибка при добавлении товара в корзину");
                }
            })
            .catch(error => console.error("Ошибка при добавлении товара:", error));
    }

    //function updateButtonState() {
    //    fetch("/Cart/GetCartItems")
    //        .then(response => response.json())
    //        .then(cartItems => {
    //            document.querySelectorAll(".add-to-cart").forEach(button => {
    //                const productId = button.getAttribute("data-product-id");
    //                if (cartItems.includes(parseInt(productId))) {
    //                    button.textContent = "Товар в корзине";
    //                    button.style.backgroundColor = "#cc6ce5";
    //                } else {
    //                    button.textContent = "Добавить в корзину 🛒";
    //                    button.style.backgroundColor = "#36d0d7";
    //                }
    //            });
    //        })
    //        .catch(error => console.error("Ошибка при получении корзины:", error));
    //}
    // Функция обновления состояния кнопок (меняет текст и цвет)
    function updateButtonState() {
        fetch("/Cart/GetCartItems")
            .then(response => response.json())
            .then(cartItems => {
                document.querySelectorAll(".add-to-cart, .add-to-cart-cartfood").forEach(button => {
                    const productId = button.getAttribute("data-product-id");
                    if (cartItems.includes(parseInt(productId))) {
                        button.textContent = "Товар в корзине";
                        button.style.backgroundColor = "#cc6ce5";
                    } else {
                        button.textContent = "Добавить в корзину 🛒";
                        button.style.backgroundColor = "#36d0d7";
                    }
                });
            })
            .catch(error => console.error("Ошибка при получении корзины:", error));
    }


    //let loadMoreButton = document.getElementById("load-more");
    //if (loadMoreButton) {
    //    loadMoreButton.addEventListener("click", function () {
    //        loadMoreButton.disabled = true;
    //        let url = "";
    //        if (currentMinPrice !== null || currentMaxPrice !== null) {
    //            url = `/Dishes/FilterByPrice?minPrice=${currentMinPrice}&maxPrice=${currentMaxPrice}&offset=${offset}`;
    //        } else {
    //            url = `/Dishes/LoadMore?offset=${offset}`;
    //        }
    //        fetch(url)
    //            .then(response => response.json())
    //            .then(data => {
    //                let container = document.getElementById("dishes-row");
    //                if (container && data.html.trim() !== "") {
    //                    container.insertAdjacentHTML("beforeend", data.html);
    //                    offset += expectedCount;
    //                    loadMoreButton.setAttribute("data-offset", offset);
    //                    updateButtonState();
    //                    if (!data.hasMore) {
    //                        loadMoreButton.style.display = "none";
    //                    } else {
    //                        loadMoreButton.disabled = false;
    //                    }
    //                } else {
    //                    loadMoreButton.style.display = "none";
    //                }
    //            })
    //            .catch(error => {
    //                console.error("Ошибка загрузки товаров:", error);
    //                loadMoreButton.disabled = false;
    //            });
    //    });
    //}

    // Обработка клика на кнопке "Загрузить ещё"
    let loadMoreButton = document.getElementById("load-more");
    if (loadMoreButton) {
        loadMoreButton.addEventListener("click", function () {
            loadMoreButton.disabled = true;
            let url = "";
            // Если фильтрация активна, то используем комбинированный запрос
            if (isFiltering) {
                url = `/Dishes/FilterDishes?minPrice=${currentMinPrice}&maxPrice=${currentMaxPrice}&minCalories=${currentMinCalories}&maxCalories=${currentMaxCalories}&offset=${offset}`;
                if (currentSelectedMeals.length > 0) {
                    url += currentSelectedMeals.map(m => `&selectedMeals=${encodeURIComponent(m)}`).join("");
                }
                if (currentSelectedDiets.length > 0) {
                    url += currentSelectedDiets.map(d => `&selectedDiets=${encodeURIComponent(d)}`).join("");
                }
            } else {
                url = `/Dishes/LoadMore?offset=${offset}`;
            }
            fetch(url)
                .then(response => response.json())
                .then(data => {
                    let container = document.getElementById("dishes-row");
                    if (container && data.html.trim() !== "") {
                        container.insertAdjacentHTML("beforeend", data.html);
                        offset += expectedCount;
                        loadMoreButton.setAttribute("data-offset", offset);
                        updateButtonState();
                        if (!data.hasMore) {
                            loadMoreButton.style.display = "none";
                        } else {
                            loadMoreButton.disabled = false;
                        }
                    } else {
                        loadMoreButton.style.display = "none";
                    }
                })
                .catch(error => {
                    console.error("Ошибка загрузки товаров:", error);
                    loadMoreButton.disabled = false;
                });
        });
    }

    // Элементы для фильтров
    let minPriceInput = document.getElementById("price-min");
    let maxPriceInput = document.getElementById("price-max");
    let priceRangeDisplay = document.getElementById("price-range-display");
    let minCaloriesInput = document.getElementById("min-calories");
    let maxCaloriesInput = document.getElementById("max-calories");
    let applyFiltersBtn = document.querySelector(".apply-filters-btn");

    // Обновление отображения диапазона цены
    function updatePriceRangeDisplay() {
        let minPrice = minPriceInput.value;
        let maxPrice = maxPriceInput.value;
        priceRangeDisplay.textContent = `${minPrice} ₽ - ${maxPrice} ₽`;
    }

    // Функция применения фильтров
    function applyFilters() {
        // Значения цены
        let minPrice = minPriceInput.value;
        let maxPrice = maxPriceInput.value;
        currentMinPrice = minPrice === "" ? 0 : minPrice;
        currentMaxPrice = maxPrice === "" ? 2000 : maxPrice;

        // Значения калорий
        let minCalories = minCaloriesInput.value;
        let maxCalories = maxCaloriesInput.value;
        currentMinCalories = minCalories === "" ? 0 : minCalories;
        currentMaxCalories = maxCalories === "" ? 500 : maxCalories;

        // Выбранные типы приёма пищи (ожидаются значения, совпадающие с d.Meal.mealName в нижнем регистре)
        currentSelectedMeals = Array.from(document.querySelectorAll('input[name="meal"]:checked'))
            .map(el => el.value.toLowerCase());

        // Выбранные диеты (ожидаются значения, совпадающие с преобразованным t.dietName)
        currentSelectedDiets = Array.from(document.querySelectorAll('input[name="tags"]:checked'))
            .map(el => el.value.toLowerCase());

        // Устанавливаем режим фильтрации
        isFiltering = true;
        // Сбрасываем offset для новой выборки
        offset = 0;

        // Формируем URL для комбинированной фильтрации
        let url = `/Dishes/FilterDishes?minPrice=${currentMinPrice}&maxPrice=${currentMaxPrice}&minCalories=${currentMinCalories}&maxCalories=${currentMaxCalories}&offset=${offset}`;
        if (currentSelectedMeals.length > 0) {
            url += currentSelectedMeals.map(m => `&selectedMeals=${encodeURIComponent(m)}`).join("");
        }
        if (currentSelectedDiets.length > 0) {
            url += currentSelectedDiets.map(d => `&selectedDiets=${encodeURIComponent(d)}`).join("");
        }

        fetch(url)
            .then(response => response.json())
            .then(data => {
                let container = document.getElementById("dishes-row");
                if (container) {
                    container.innerHTML = "";
                    container.insertAdjacentHTML("beforeend", data.html);
                }
                updateButtonState();
                offset += expectedCount;
                if (loadMoreButton) {
                    if (!data.hasMore) {
                        loadMoreButton.style.display = "none";
                    } else {
                        loadMoreButton.style.display = "block";
                        loadMoreButton.setAttribute("data-offset", offset);
                        loadMoreButton.disabled = false;
                    }
                }
            })
            .catch(error => console.error("Ошибка при фильтрации:", error));
    }


    function removeFromCart(productId) {
        console.log("Отправка запроса на удаление товара с id:", productId);
        fetch("/Cart/RemoveFromCart", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ dishId: parseInt(productId, 10) })
        })
            .then(response => response.json())
            .then(data => {
                console.log("Ответ от сервера:", data);
                if (data.success) {
                    let itemElement = document.querySelector(`.cart-item[data-id="${productId}"]`);
                    if (itemElement) {
                        itemElement.remove();
                    }
                    const totalPriceElement = document.getElementById("total-price");
                    if (totalPriceElement) {
                        totalPriceElement.textContent = data.totalPrice + " ₽";
                    }
                    updateButtonState();
                } else {
                    alert("Ошибка: " + data.message);
                }
            })
            .catch(error => console.error("Ошибка при удалении товара:", error));
    }

    document.addEventListener("click", function (e) {
        const removeButton = e.target.closest(".remove-from-cart");
        if (removeButton) {
            const productId = removeButton.getAttribute("data-product-id");
            console.log("Нажата кнопка удаления для productId:", productId);
            if (productId) {
                removeFromCart(productId);
            }
        }
    });

    if (minPriceInput && maxPriceInput && priceRangeDisplay && applyFiltersBtn) {
        minPriceInput.addEventListener("input", updatePriceRangeDisplay);
        maxPriceInput.addEventListener("input", updatePriceRangeDisplay);
        applyFiltersBtn.addEventListener("click", applyFilters);

    }


    updateButtonState();
});

