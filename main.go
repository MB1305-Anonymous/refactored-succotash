package main

import (
	"errors"
	"fmt"
	"sync"
)

// Account represents a bank account
type Account struct {
	Username string
	Balance  float64
}

// Bank holds all the accounts
type Bank struct {
	mu       sync.Mutex
	Accounts map[string]*Account
}

// NewBank initializes a new bank
func NewBank() *Bank {
	return &Bank{
		Accounts: make(map[string]*Account),
	}
}

// CreateAccount creates a new account
func (b *Bank) CreateAccount(username string) error {
	b.mu.Lock()
	defer b.mu.Unlock()

	if _, exists := b.Accounts[username]; exists {
		return errors.New("account already exists")
	}

	b.Accounts[username] = &Account{Username: username, Balance: 0}
	return nil
}

// Deposit adds funds to an account
func (b *Bank) Deposit(username string, amount float64) error {
	b.mu.Lock()
	defer b.mu.Unlock()

	account, exists := b.Accounts[username]
	if !exists {
		return errors.New("account not found")
	}

	if amount <= 0 {
		return errors.New("amount must be greater than zero")
	}

	account.Balance += amount
	return nil
}

// Withdraw removes funds from an account
func (b *Bank) Withdraw(username string, amount float64) error {
	b.mu.Lock()
	defer b.mu.Unlock()

	account, exists := b.Accounts[username]
	if !exists {
		return errors.New("account not found")
	}

	if amount <= 0 {
		return errors.New("amount must be greater than zero")
	}

	if account.Balance < amount {
		return errors.New("insufficient funds")
	}

	account.Balance -= amount
	return nil
}

// Transfer funds from one account to another
func (b *Bank) Transfer(fromUsername, toUsername string, amount float64) error {
	b.mu.Lock()
	defer b.mu.Unlock()

	fromAccount, fromExists := b.Accounts[fromUsername]
	toAccount, toExists := b.Accounts[toUsername]

	if !fromExists {
		return errors.New("from account not found")
	}

	if !toExists {
		return errors.New("to account not found")
	}

	if amount <= 0 {
		return errors.New("amount must be greater than zero")
	}

	if fromAccount.Balance < amount {
		return errors.New("insufficient funds")
	}

	fromAccount.Balance -= amount
	toAccount.Balance += amount
	return nil
}

// CheckBalance returns the balance of an account
func (b *Bank) CheckBalance(username string) (float64, error) {
	b.mu.Lock()
	defer b.mu.Unlock()

	account, exists := b.Accounts[username]
	if !exists {
		return 0, errors.New("account not found")
	}

	return account.Balance, nil
}

// Main function to run the console app
func main() {
	bank := NewBank()
	var choice int
	var username string
	var amount float64

	for {
		fmt.Println("\nWelcome to the Bank App")
		fmt.Println("1. Create Account")
		fmt.Println("2. Deposit")
		fmt.Println("3. Withdraw")
		fmt.Println("4. Transfer Funds")
		fmt.Println("5. Check Balance")
		fmt.Println("6. Exit")
		fmt.Print("Choose an option: ")
		fmt.Scan(&choice)

		switch choice {
		case 1:
			fmt.Print("Enter username to create account: ")
			fmt.Scan(&username)
			err := bank.CreateAccount(username)
			if err != nil {
				fmt.Println("Error:", err)
			} else {
				fmt.Println("Account created successfully!")
			}
		case 2:
			fmt.Print("Enter username: ")
			fmt.Scan(&username)
			fmt.Print("Enter amount to deposit: ")
			fmt.Scan(&amount)
			err := bank.Deposit(username, amount)
			if err != nil {
				fmt.Println("Error:", err)
			} else {
				fmt.Println("Deposit successful!")
			}
		case 3:
			fmt.Print("Enter username: ")
			fmt.Scan(&username)
			fmt.Print("Enter amount to withdraw: ")
			fmt.Scan(&amount)
			err := bank.Withdraw(username, amount)
			if err != nil {
				fmt.Println("Error:", err)
			} else {
				fmt.Println("Withdrawal successful!")
			}
		case 4:
			var toUsername string
			fmt.Print("Enter your username: ")
			fmt.Scan(&username)
			fmt.Print("Enter recipient username: ")
			fmt.Scan(&toUsername)
			fmt.Print("Enter amount to transfer: ")
			fmt.Scan(&amount)
			err := bank.Transfer(username, toUsername, amount)
			if err != nil {
				fmt.Println("Error:", err)
			} else {
				fmt.Println("Transfer successful!")
			}
		case 5:
			fmt.Print("Enter username to check balance: ")
			fmt.Scan(&username)
			balance, err := bank.CheckBalance(username)
			if err != nil {
				fmt.Println("Error:", err)
			} else {
				fmt.Printf("Balance for %s: $%.2f\n", username, balance)
			}
		case 6:
			fmt.Println("Exiting the application.")
			return
		default:
			fmt.Println("Invalid option. Please try again.")
		}
	}
}
