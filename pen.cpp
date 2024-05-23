#include <iostream>
#include <map>
int main(){
	std::map <int,int> pencils;
	int n, currentpencil, changedpen=-1,doublepen=0;
	int sum1=0, sum2=0;
	std::cin>>n;
	for (int i=1;i<=n;i++){
		std::cin>>currentpencil;
		pencils[currentpencil]++;
		if (pencils[currentpencil]>1){
			doublepen=currentpencil;
		}
		sum1+=i;
		sum2+=currentpencil;
	}
	if (doublepen){
		if (sum1>(sum2-doublepen)) changedpen=sum1-(sum2-doublepen);
		else changedpen=(sum2-doublepen)-sum1;
	}
	std::cout<<changedpen;
}

