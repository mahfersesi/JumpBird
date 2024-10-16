namespace JumpBird;

public partial class MainPage : ContentPage
{
	const int AberturaMinima=200;
	const int forcaPulo=30;
	const int maxTempoPulando=3;//frames
	bool estaPulando=false;	
	int tempoPulando=0;
	const int TempoEntreFrames = 25;
	const int Gravidade = 3;
	double LarguraJanela;
	double AlturaJanela;
	int velocidade = 20;
	bool estaMorto = true;
	public MainPage()
	{
		InitializeComponent();
	}

  public async void Desenha()
  {
	while (!estaMorto)
	{
		GerenciaCanos();
		if (VerificaColisao())
		{
			estaMorto=true;
			GameOverFrame.IsVisible=true;
			break;
		}
		if (estaPulando)
		  AplicaPulo();
		else
			AplicaGravidade();
		await Task.Delay(TempoEntreFrames);
	}
  }
	void AplicaPulo()
	{
		Passaro.TranslationY-=forcaPulo;
		tempoPulando++;
		if (tempoPulando >= maxTempoPulando)
		{
			estaPulando=false;
			tempoPulando=0;
		}
	}
	void OnGridCliked(object sender, TappedEventArgs e)
	{
		estaPulando=true;
	}
	void AplicaGravidade()
	{
		Passaro.TranslationY += Gravidade;
	
	}

	
	protected override void OnSizeAllocated(double w, double h)
	{
		base.OnSizeAllocated(w, h);
		LarguraJanela = w;
		AlturaJanela = h;
		
	}
	void GerenciaCanos()
	{
		imgCanoCima.TranslationX -= velocidade;
		imgCanoBaixo.TranslationX -= velocidade;

		if (imgCanoBaixo.TranslationX <- LarguraJanela)
		{
			imgCanoBaixo.TranslationX = 0;
			imgCanoCima.TranslationX = 0;
			var alturaMax=-100;
			var alturaMin=-imgCanoBaixo.HeightRequest;
			imgCanoCima.TranslationY=Random.Shared.Next((int)alturaMin, (int)alturaMax);
			imgCanoBaixo.TranslationY=imgCanoCima.TranslationY+AberturaMinima+imgCanoBaixo.HeightRequest;
		}
	
	}


	void Ei(object s, TappedEventArgs e)
	{
		GameOverFrame.IsVisible = false;
		estaMorto = false;
		Inicializar();
		Desenha();
	}
	void Inicializar()
	{
		Passaro.TranslationY = 0;
	}
	bool VerificaColisaoTeto()
	{
		var minY=-AlturaJanela/2;
		if (Passaro.TranslationY <= minY)
		return true;
		else
		return false;
	}
	bool VerificaColisaoChao()
	{
		var maxY=AlturaJanela/2;
		if(Passaro.TranslationY >= maxY)
		return true;
		else 
		return false;
	}

	bool VerificaColisao()
	{
		if(! estaMorto)
		{
			if(VerificaColisaoTeto() ||
				VerificaColisaoChao())
		{
			return true;
		}
		}
		return false;
	}

}

