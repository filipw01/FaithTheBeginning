// Fill out your copyright notice in the Description page of Project Settings.

#include "FaithTheBeginning.h"
#include "MainCharacter.h"


// Sets default values
AMainCharacter::AMainCharacter()
{
 	// Set this pawn to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	AutoPossessPlayer = EAutoReceiveInput::Player0;

	RootComponent = CreateDefaultSubobject<USceneComponent>(TEXT("RootComponent"));
	VisibleComponent = CreateDefaultSubobject<UStaticMeshComponent>(TEXT("VisibleComponent"));
	UCameraComponent* Camera = CreateDefaultSubobject<UCameraComponent>(TEXT("Camera"));
	Camera->SetupAttachment(RootComponent);
	Camera->SetRelativeRotation(FRotator(0.0f, -90.0f, 0.0f));
	Camera->SetRelativeLocation(FVector(0.0f, 250.0f, 100.0f));
}

// Called when the game starts or when spawned
void AMainCharacter::BeginPlay()
{
	Super::BeginPlay();
	
}

// Called every frame
void AMainCharacter::Tick( float DeltaTime )
{
	Super::Tick( DeltaTime );
	ActorLocation = GetActorLocation();
	
	if(!CurrentVelocity.IsZero())
	{
		FVector NewLocation = ActorLocation + (CurrentVelocity * DeltaTime);
		SetActorLocation(NewLocation);
	}
	if(CurrentVelocity.Z > 0.0f)
	{
		CurrentVelocity.Z -= 100.0f;
	}
	if(ActorLocation.Z<=30.0f)
	{
		CurrentVelocity.Z = 0.0f;
	}
	if(CurrentVelocity.Z<0.0f)
	{
		CurrentVelocity.Z -= 100.0f;
	}
	if(CurrentVelocity.Z==0.0f && ActorLocation.Z>=30.0f)
	{
		CurrentVelocity.Z -= 100.0f;
	}

}

// Called to bind functionality to input
void AMainCharacter::SetupPlayerInputComponent(class UInputComponent* InputComponent)
{
	Super::SetupPlayerInputComponent(InputComponent);
	InputComponent->BindAction("Jump", IE_Pressed, this, &AMainCharacter::DoJump);
	InputComponent->BindAxis("Move", this, &AMainCharacter::Move);
}

void AMainCharacter::Move(float value)
{
	CurrentVelocity.X = FMath::Clamp(value, -1.0f, 1.0f)*100.0f;
}
void AMainCharacter::DoJump()
{
	CurrentVelocity.Z = 1000.0f;
}


