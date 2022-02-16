using System;
using BankLibrary;
using System.Linq;
using System.Collections.Generic;

namespace BankFunctionalities
{
    public class BankFunc : IBankingFunc
    {   
        BankRepository bankRepo = new BankRepository();
        
        public void FundTransfer(){

            int account_from,account_to,fund_amount;
            //bool flag = false ;

            System.Console.WriteLine("Enter Account No. to transfer fund from ");
            account_from = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Enter Account No. to transfer fund to ");
            account_to = int.Parse(Console.ReadLine());

            var check_account1 = bankRepo.GetAccountDetails(account_from);
            var check_account2 = bankRepo.GetAccountDetails(account_to);
            //System.Console.WriteLine(check_account1);

            if(check_account1 != null && check_account2 != null){
                System.Console.WriteLine("Fund can be Processed");
                System.Console.WriteLine("Enter Fund Amount to transfer");
                fund_amount = int.Parse(Console.ReadLine());

                try{
                bankRepo.WithdrawAmount(account_from,fund_amount);
                bankRepo.DepositAmount(account_to,fund_amount);
                }
                catch(Exception){   }
            }
            else{
                System.Console.WriteLine("Fund can't be Processed ");
            }
            
        }
        public void RaiseLoan(){

            System.Console.WriteLine("Enter Account Number to check the balance required for initiating Loan");
            int acc_no = int.Parse(Console.ReadLine());
            
               var check_acc = bankRepo.GetAccountDetails(acc_no);
               var sbaccount = bankRepo.GetAllAccounts();
            
            if(check_acc != null){

                System.Console.WriteLine("Account Verified !");
                System.Console.WriteLine("Enter Loan amount ");
                int loan_amount = int.Parse(Console.ReadLine());

                var a  = (from i in sbaccount where i.AccountNo == acc_no select i);

                foreach(var i in a){
                   // System.Console.WriteLine(i.AccountNo+ " "+i.CurrentBalance);
                    if(i.CurrentBalance < loan_amount ){
                        System.Console.WriteLine("Loan can't be raised as your current balance is : {0} and amount required for Loan is : {1} ",
                        i.CurrentBalance,loan_amount);
                    }
                    else{
                        System.Console.WriteLine("Loan can be Raised with 3% of interest on "+loan_amount);
                        System.Console.WriteLine("Calculated Interest Amount is Rs.{0} per month.", (0.03*loan_amount) );
                    }
                }
                

            }
            else{
                System.Console.WriteLine("Invalid Account Eneterd !");
            }
         

        }
    }
    
}
