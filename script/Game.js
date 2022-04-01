export default class Game
{

    #grid = [
        document.querySelector("#box1"), //0 p
        document.querySelector("#box2"), //1 a
        document.querySelector("#box3"), //2 k
        document.querySelector("#box4"), //3 p
        document.querySelector("#box5"), //4 a
        document.querySelector("#box6"), //5 k
        document.querySelector("#box7"), //6 p
        document.querySelector("#box8"), //7 a
        document.querySelector("#box9") //8  k
    ]

    #resetGame = document.querySelector(".reset")

    #caseGrid = document.querySelector(".game-grid")

    #bodyDOM = document.querySelector("body")

    #gameOver = false

    resetGameTable()
    {
        this.#resetGame.addEventListener("click", e => {
            e.preventDefault()
            this.#grid.forEach( box => box.classList.remove("fa-solid", "fa-xmark", "fa-circle", "fa-regular"))

            this.#gameOver = false

            if(this.#bodyDOM.children[2].classList.contains("message"))
                this.#bodyDOM.removeChild(this.#bodyDOM.children[2])
        })
    }

    #checkVictoryCross(char)
    {
        let victory = false
        if(this.#grid[0].classList.contains(char) && this.#grid[4].classList.contains(char) && this.#grid[8].classList.contains(char))
            victory = true
        else if(this.#grid[2].classList.contains(char) && this.#grid[4].classList.contains(char) && this.#grid[6].classList.contains(char))
            victory = true

        return victory
    }

    #checkVictoryColum(char)
    {
        let victory = false
        let counter = 0

        for(let i=0; i<3; i++)
        {
            for(let x = i; x<9; x+=3)
            {
                if(this.#grid[x].classList.contains(char))
                    counter++
            
                if(counter >= 3)
                    victory = true
            }

            counter = 0
        }

        return victory
    }

    #checkVictoryFill(char)
    {
        let victory = false
        let counter = 0

        for(let i =0 ; i<9; i++)
        {
            if(this.#grid[i].classList.contains(char))
                counter++
            
            if(counter >= 3)
                victory = true

            if(i===2 || i===5)
                counter = 0

        }
        
        return victory
    } 

    

    setMoveTable()
    {
        this.#caseGrid.addEventListener("click", e => {

            if(!this.#gameOver){
                if(this.#selecBoxMove(e.target))
                this.#setMoveOponent(e.target)
            }

            if((this.#checkVictoryColum("fa-xmark") || this.#checkVictoryFill("fa-xmark") || this.#checkVictoryCross("fa-xmark")) && !this.#gameOver){
                this.#gameOver = true
                console.log("Entre")
                this.#showMessage("win")
            }

            if((this.#checkVictoryColum("fa-circle") || this.#checkVictoryFill("fa-circle") || this.#checkVictoryCross("fa-circle")) && !this.#gameOver){
                this.#gameOver = true
                console.log("Entre")
                this.#showMessage()
            }
        
        })
        
    }

    #showMessage(opt)
    {
        const messge = document.createElement("p")
        messge.classList.add("message")

        if(opt === "win")
        {
            messge.textContent = "You win"
            messge.classList.add("win")
        }else
        {
            messge.textContent = "You lose"
            messge.classList.add("defeat")
        }

        this.#bodyDOM.insertBefore(messge, this.#resetGame)
    
    }

    #selecBoxMove(boxTarg)
    {
         
        if(boxTarg.classList.contains("box") && !(boxTarg.classList.contains("fa-circle") || boxTarg.classList.contains("fa-xmark")))
        {
            boxTarg.classList.add("fa-solid", "fa-xmark")

            return true
        }

        return false
    }

    #setMoveOponent(boxTarg)
    {
        if(boxTarg.classList.contains("box"))
        {
            let n = 0, ok = false
            this.#grid.forEach(box => {
                if(box.classList.contains("fa-xmark") || box.classList.contains("fa-circle"))
                    n++
            })
            if(n >= 9)
                ok = true
            
            while(!ok)
            {
                let move = (Math.floor(Math.random()*(9-1+1)+1)) - 1

                if(!(this.#grid[move].classList.contains("fa-xmark") || this.#grid[move].classList.contains("fa-circle")))
                {
                    this.#grid[move].classList.add("fa-regular", "fa-circle")

                    break
                }
                
            }
        }
           
    }

}
